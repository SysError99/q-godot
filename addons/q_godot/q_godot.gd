extends Node


const _BOUND_QUERIES = "#BQN"
const _ENTITY = "#E"
const _REGISTERED_SCENE = "#RS"
const _SHARED_VAR = 1
const _SYSTEM_CLASS = 0
const _SYSTEM_INSTANCE = "#SI"
const _UNREGISTERED_SCENE = "registered_scene"


class Query extends Object:
	var component_names := []
	var parent_class_name := ""
	var subscribers := []
	var current_scene_subscribers := []
	func add_subscriber(new_subscriber: Array, to_current_scene: bool) -> void:
		subscribers.push_back(new_subscriber)
		if to_current_scene:
			current_scene_subscribers.push_back(new_subscriber)
	func remove_current_scene_subscribers() -> void:
		for element in current_scene_subscribers:
			subscribers.erase(element)
		current_scene_subscribers.clear()


class HalfQueryReference extends Object:
	var switch := false
	var first_half := []
	var second_half := []
	func iterate() -> Array:
		switch = not switch
		if switch:
			return first_half
		else:
			return second_half


signal query_ready()
signal query_added(query_name)
signal added_to_query(query_name, binds)
signal removed_from_query(query_name, binds)


var _queries := {}
var _query_cache := {}
var _query_half_cache := {}
var _regex := RegEx.new()
var _root: Viewport
var _scene_changing := true
var _tree: SceneTree


# Bind a query to an object or an instantiable object. If you bind a query to instantiated object, 'shared' parameter will be function name string.
func bind_query(parent_class_name: String, component_names: Array = [], system: Object = null, shared = null, to_current_scene: bool = false) -> void:
	var query_name := __get_query_name(parent_class_name, component_names)
	var query_obj: Query
	if query_name in _queries:
		query_obj = _queries[query_name]
	else:
		query_obj = Query.new()
		query_obj.component_names = component_names
		query_obj.parent_class_name = parent_class_name
		if not query_name in _query_cache:
			_query_cache[query_name] = []
		if _scene_changing:
			yield(self, "query_ready")
		if not query_name in _queries:
			_queries[query_name] = query_obj
			emit_signal("query_added", query_name)
			for scene in _tree.get_nodes_in_group(_REGISTERED_SCENE):
				for entity in scene.get_children():
					__bind_to_query_object(entity, query_name, parent_class_name, component_names)
	if is_instance_valid(system):
		var new_subscriber := [system, shared]
		var subscribers := [ new_subscriber ]
		query_obj.add_subscriber(new_subscriber, to_current_scene)
		for entity_ref in _query_cache[query_name]:
			__bind_to_systems(entity_ref, query_name, subscribers)


# Bind a query to an object or an instantiable object for current scene. If you bind a query to instantiated object, 'shared' parameter will be function name string.
func bind_query_to_current_scene(parent_class_name: String, component_names: Array = [], system: Object = null, shared = null) -> void:
	bind_query(parent_class_name, component_names, system, shared, true)


# Obtain a query array.
func query(parent_class_name: String, component_names: Array) -> Array:
	var query_name := __get_query_name(parent_class_name, component_names)
	if query_name in _query_cache:
		return _query_cache[query_name]
	bind_query(parent_class_name, component_names)
	return _query_cache[query_name]


# Obtain a half-iteratable query.
func query_half(parent_class_name: String, component_names: Array) -> HalfQueryReference:
	var query_name := __get_query_name(parent_class_name, component_names)
	if  query_name in _query_half_cache:
		return _query_half_cache[query_name]
	var query_array := query(parent_class_name, component_names)
	var query_size := query_array.size()
	var query_half_size := query_size / 2
	var q := HalfQueryReference.new()
	q.first_half = query_array.slice(0, query_half_size - 1)
	if query_size > 1:
		q.second_half = query_array.slice(query_half_size, query_array.size())
	_query_half_cache[query_name] = q
	return q


# Change scene with internal function, mandatory to make querying system working properly!
func change_scene(path: String) -> void:
	_scene_changing = true
	var current_scene := _tree.current_scene
	var inst := (load(path) as PackedScene).instance()
	for scene in _tree.get_nodes_in_group(_REGISTERED_SCENE):
		__remove_entities_from_current_scene(scene)
	for query_name in _queries:
		_queries[query_name].call("remove_current_scene_subscribers")
	current_scene.queue_free()
	yield(current_scene, "tree_exited")
	_root.set_meta("current_scene", inst)
	_root.call_deferred("add_child", inst)
	_tree.set_deferred("current_scene", inst)
	yield(inst, "ready")
	_scene_changing = false
	__post_change_scene(inst)


# Register specified node as a scene node.
func register_as_scene(node: Node) -> void:
	node.add_to_group(_REGISTERED_SCENE)
	if node.is_in_group(_UNREGISTERED_SCENE):
		node.remove_from_group(_UNREGISTERED_SCENE)
	for child_ref in node.get_children():
		__register_entity(child_ref)
	node.connect("child_entered_tree", self, "_entity_entered_scene")
	node.connect("child_exiting_tree", self, "_entity_exiting_scene")


# Add specified node to a group, and perform query bindings.
func add_node_to_group(node: Node, group_name: String) -> void:
	__register_entity(node)
	node.add_to_group(group_name)
	var bound_queries := node.get_meta(_BOUND_QUERIES, []) as Array
	for query_name in _queries:
		if query_name in bound_queries:
			continue
		var query_obj := _queries[query_name] as Query
		if __bind_to_query_object(node, query_name, query_obj.parent_class_name, query_obj.component_names):
			var subscribers := query_obj.subscribers
			if subscribers.size() > 0:
				__bind_to_systems(node, query_name, subscribers)


# Remove specified node to a group, and perform query bindings.
func remove_node_from_group(node: Node, group_name: String) -> void:
	node.remove_from_group(group_name)
	var index := 0
	var bound_queries := node.get_meta(_BOUND_QUERIES, []) as Array
	while index < bound_queries.size():
		var query_name := bound_queries[index] as String
		if not group_name in query_name:
			index += 1
			continue
		__remove_query_from_entity(node, query_name)
		bound_queries.remove(index)


func __get_query_name(parent_class_name: String, component_names: Array) -> String:
	return parent_class_name + "," + PoolStringArray(component_names).join(",")


func __bind_to_query_object(entity: Node, query_name: String, parent_class_name: String, component_names: Array) -> bool:
	if entity.get_class() != parent_class_name:
		return false
	var binds := []
	var named_binds := {}
	var number_of_groups := 0
	var bound_queries := entity.get_meta(_BOUND_QUERIES) as Array
	for component_name in component_names:
		if entity.is_in_group(component_name):
			number_of_groups += 1
			continue
		var component := entity.get_node_or_null(component_name)
		if not is_instance_valid(component):
			return false
		binds.push_back(component)
		entity.set_meta("$" + component_name, component)
		var bind_name := _regex.sub(component.name, "_$1", true).to_lower()
		named_binds[bind_name.substr(1, bind_name.length())] = component
	if binds.size() == component_names.size() - number_of_groups:
		bound_queries.push_back(query_name)
		entity.set_meta("?" + query_name, [])
		entity.set_meta("#" + query_name, binds)
		entity.set_meta("##" + query_name, named_binds)
		var cache := _query_cache[query_name] as Array
		cache.push_back(entity)
		if query_name in _query_half_cache:
			var half_cache := _query_half_cache[query_name] as HalfQueryReference
			if cache.size() % 2 == 0:
				half_cache.second_half.push_back(entity)
			else:
				half_cache.first_half.push_back(entity)
		emit_signal("added_to_query", query_name, binds)
		return true
	return false


func __bind_to_systems(entity: Object, query_name: String, subscribers: Array) -> void:
	var entity_id := "%s_%d" % [query_name, entity.get_instance_id()]
	var named_binds := entity.get_meta("##" + query_name) as Dictionary
	var bound_systems := entity.get_meta("?" + query_name) as Array
	var binds := entity.get_meta("#" + query_name) as Array
	var ebinds := [ entity ] + binds
	for system_ref in subscribers:
		var system := system_ref[_SYSTEM_CLASS] as Object
		if system.has_meta(entity_id):
			continue
		bound_systems.push_back(system)
		if system.has_method("new"):
			var system_inst := system.new() as Object
			system_inst.set("parent", entity)
			system_inst.set("shared", system_ref[_SHARED_VAR])
			for bind_name in named_binds:
				system_inst.set(bind_name, named_binds[bind_name])
			system.set_meta(entity_id, system_inst)
			system.set_meta(_SYSTEM_INSTANCE, true)
			entity.add_child(system_inst)
		else:
			system.callv(system_ref[_SHARED_VAR], ebinds)
			system.set_meta(entity_id, system)


func __remove_entities_from_current_scene(scene: Node) -> void:
	if scene.is_in_group("persistent_scene"):
		return
	for entity in scene.get_children():
		if not entity.has_meta(_BOUND_QUERIES):
			continue
		for query_name in entity.get_meta(_BOUND_QUERIES):
			__remove_entity_from_query(query_name, entity, entity.get_meta("#" + query_name))


func __remove_query_from_entity(entity: Node, query_name: String) -> void:
	var entity_id := "%s_%d" % [query_name, entity.get_instance_id()]
	for system in entity.get_meta("?" + query_name):
		var system_inst := system.get_meta(entity_id) as Object
		system.remove_meta(entity_id)
		if system_inst.get_meta(_SYSTEM_INSTANCE, false):
			system_inst.call_deferred("free")
	__remove_entity_from_query(query_name, entity, entity.get_meta("#" + query_name))
	entity.remove_meta("#" + query_name)
	entity.remove_meta("?" + query_name)
	entity.remove_meta("##" + query_name)


func __remove_entity_from_query(query_name: String, entity: Node, binds: Array) -> void:
	(_query_cache[query_name] as Array).erase(entity)
	if query_name in _query_half_cache:
		var query_half := _query_half_cache[query_name] as HalfQueryReference
		query_half.first_half.erase(entity)
		query_half.second_half.erase(entity)
	emit_signal("removed_from_query", query_name, binds)


func __post_change_scene(current_scene: Node) -> void:
	var unregistered_scenes := _tree.get_nodes_in_group(_UNREGISTERED_SCENE)
	if unregistered_scenes.size() > 0:
		for scn_ref in unregistered_scenes:
			register_as_scene(scn_ref)
	else:
		register_as_scene(current_scene)
	yield(_tree, "idle_frame")
	emit_signal("query_ready")


func __register_entity(entity: Node) -> void:
	if entity.is_in_group(_ENTITY):
		return
	var bound_queries := []
	entity.add_to_group(_ENTITY)
	entity.set_meta(_BOUND_QUERIES, bound_queries)
	entity.connect("child_entered_tree", self, "_entity_component_added", [ entity, bound_queries ])
	entity.connect("child_exiting_tree", self, "_entity_component_removed", [ entity, bound_queries])
	for query_name in _queries:
		var query_obj := _queries[query_name] as Query
		if __bind_to_query_object(entity, query_name, query_obj.parent_class_name, query_obj.component_names):
			var subscribers := query_obj.subscribers
			if subscribers.size() > 0:
				__bind_to_systems(entity, query_name, subscribers)


func _entity_entered_scene(entity: Node) -> void:
	yield(entity, "ready")
	__register_entity(entity)


func _entity_exiting_scene(entity: Node) -> void:
	if _scene_changing:
		return
	for group in entity.get_groups():
		match group[0]:
			"#","$":
				continue
			_:
				for query_name in _query_cache:
					if group in query_name:
						__remove_entity_from_query(query_name, entity, [ entity ])


func _entity_component_added(component: Node, entity: Node, bound_queries: Array) -> void:
	var component_name := component.name
	for query_name in _queries:
		if query_name in bound_queries:
			continue
		if component_name in query_name:
			var query_obj := _queries[query_name] as Query
			if __bind_to_query_object(entity, query_name, query_obj.parent_class_name, query_obj.component_names):
				__bind_to_systems(entity, query_name, query_obj.subscribers)


func _entity_component_removed(component: Node, entity: Node, bound_queries: Array) -> void:
	if _scene_changing:
		return;
	var index := 0
	var component_name := component.name
	entity.remove_meta("$" + component_name)
	while index < bound_queries.size():
		var query_name := bound_queries[index] as String
		if not component_name in query_name:
			index += 1
			continue
		__remove_query_from_entity(entity, query_name)
		bound_queries.remove(index)


func _init() -> void:
	add_to_group("#q-godot")
	_regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	_tree = get_tree()
	_root = _tree.root


func _ready() -> void:
	yield(_root, "ready")
	_scene_changing = false
	__post_change_scene(_tree.current_scene)
