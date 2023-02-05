extends Node


const _COMP_ZERO_ERR = "'component_names' must have at least one member!"


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
var _root_ready := false
var _root: Viewport
var _scene_changing := false
var _tree: SceneTree


# Bind a query to an object or an instantiable object. If you bind a query to instantiated object, 'shared' parameter will be function name string.
func bind_query(component_names: Array, system: Object = null, shared = null, to_current_scene: bool = false) -> void:
	assert(component_names.size() > 0, _COMP_ZERO_ERR)
	var query_name := __get_query_name(component_names)
	var query_obj: Query
	if query_name in _queries:
		query_obj = _queries[query_name]
	else:
		query_obj = Query.new()
		_query_cache[query_name] = []	
		query_obj.component_names = component_names
		query_obj.parent_class_name = component_names[0]
		component_names.remove(0)
		if not _root_ready:
			yield(_root, "ready")
		if _scene_changing:
			yield(self, "query_ready")
		_queries[query_name] = query_obj
		emit_signal("query_added", query_name)
		for scene_ref in _tree.get_nodes_in_group(_REGISTERED_SCENE):
			var scene := scene_ref as Node
			for entity in scene.get_children():
				if entity.is_in_group(_REGISTERED_SCENE):
					continue
				__bind_to_query_object(entity, query_name, query_obj)
	if is_instance_valid(system):
		var new_subscriber := [system, shared]
		var subscribers := [ new_subscriber ]
		query_obj.add_subscriber(new_subscriber, to_current_scene)
		for entity_ref in _query_cache[query_name]:
			__bind_to_systems(entity_ref, query_name, subscribers)


# Bind a query to an object or an instantiable object for current scene. If you bind a query to instantiated object, 'shared' parameter will be function name string.
func bind_query_to_current_scene(component_names: Array, system: Object = null, shared = null) -> void:
	bind_query(component_names, system, shared, true)


# Obtain a query array.
func query(component_names: Array) -> Array:
	var query_name := __get_query_name(component_names)
	if query_name in _query_cache:
		return _query_cache[query_name]
	bind_query(component_names)
	return _query_cache[query_name]


# Obtain a half-iteratable query.
func query_half(component_names: Array) -> HalfQueryReference:
	var query_name := __get_query_name(component_names)
	if  query_name in _query_half_cache:
		return _query_half_cache[query_name]
	var q := HalfQueryReference.new()
	var query_array := query(component_names)
	var query_size := query_array.size()
	var query_half_size := query_size / 2
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
	__post_change_scene(inst)
	_scene_changing = false


# Register specified node as a scene node.
func register_as_scene(node: Node) -> void:
	node.add_to_group(_REGISTERED_SCENE)
	if node.is_in_group(_UNREGISTERED_SCENE):
		node.remove_from_group(_UNREGISTERED_SCENE)
	for child_ref in node.get_children():
		__register_entity(child_ref)
	node.connect("child_entered_tree", self, "_entity_entered_scene")
	node.connect("child_exiting_tree", self, "_entity_exiting_scene")


func __get_query_name(component_names: Array) -> String:
	return PoolStringArray(component_names).join("_")


func __bind_to_query_object(entity: Node, query_name: String, query_obj: Query) -> bool:
	if entity.get_class() != query_obj.parent_class_name:
		return false
	var number_of_groups := 0
	var component_names = query_obj.component_names
	var binds := entity.get_meta("#" + query_name, []) as Array
	var bound_queries := entity.get_meta(_BOUND_QUERIES, []) as Array
	for component_name in component_names:
		if entity.is_in_group(component_name):
			number_of_groups += 1
			continue
		var component := entity.get_node_or_null(component_name)
		if not is_instance_valid(component):
			return false
		binds.push_back(component)
		entity.set_meta("$" + component_name, component)
		if not component.is_connected("tree_exited", self, "_entity_component_removed"):
			component.connect("tree_exited", self, "_entity_component_removed", [ entity, component.name, bound_queries], CONNECT_ONESHOT)
	if binds.size() == component_names.size() - number_of_groups:
		binds.push_front(entity)
		bound_queries.push_back(query_name)
		entity.add_to_group(query_name)
		entity.set_meta("#" + query_name, binds)
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
	var entity_id := String(entity.get_instance_id())
	var binds := entity.get_meta("#" + query_name, []) as Array
	var bound_systems := entity.get_meta("$" + query_name, []) as Array
	entity.set_meta("$" + query_name, bound_systems)
	for system_ref in subscribers:
		var system := system_ref[_SYSTEM_CLASS] as Object
		if system.has_meta(entity_id):
			continue
		bound_systems.push_back(system)
		if system.has_method("new"):
			var component_binds := binds.duplicate()
			var system_inst := system.new() as Object
			component_binds.remove(0)
			system_inst.set("parent", entity)
			system_inst.set("shared", system_ref[_SHARED_VAR])
			for component in component_binds:
				var bind_name := _regex.sub(component.name, "_$1", true).to_lower()
				system_inst.set(bind_name.substr(1, bind_name.length()), component)
			system.set_meta(entity_id, system_inst)
			system.set_meta(_SYSTEM_INSTANCE, true)
			entity.add_child(system_inst)
		else:
			system.callv(system_ref[_SHARED_VAR], binds)
			system.set_meta(entity_id, system)


func __remove_entities_from_current_scene(scene: Node) -> void:
	if scene.is_in_group("persistent_scene"):
		return
	for entity in scene.get_children():
		if entity.is_in_group(_REGISTERED_SCENE):
			__remove_entities_from_current_scene(entity)
			continue
		if not entity.has_meta(_BOUND_QUERIES):
			continue
		for query_name in entity.get_meta(_BOUND_QUERIES):
			__remove_entity_from_query(query_name, entity.get_meta("#" + query_name))


func __remove_entity_from_query(query_name: String, binds: Array) -> void:
	var entity := binds[0] as Object
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
	entity.connect("child_entered_tree", self, "_entity_component_added", [ entity ])
	entity.set_meta(_BOUND_QUERIES, [])
	entity.add_to_group(_ENTITY)
	for query_name in _queries:
		var query_obj := _queries[query_name] as Query
		if __bind_to_query_object(entity, query_name, query_obj):
			__bind_to_systems(entity, query_name, query_obj.subscribers)


func __array_erase_deferred(array: Array, element) -> void:
	yield(_tree, "idle_frame")
	array.erase(element)


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
						__remove_entity_from_query(query_name, [ entity ])


func _entity_component_added(_new_component: Node, entity) -> void:
	var component_name := _new_component.name
	for query_name in _queries:
		if component_name in query_name:
			var query_obj := _queries[query_name] as Query
			__bind_to_query_object(entity, query_name, query_obj)


func _entity_component_removed(entity: Node, component_name: String, bound_queries: Array) -> void:
	if _scene_changing:
		return;
	entity.remove_meta("$" + component_name)
	for query_name in bound_queries:
		if not component_name in query_name:
			continue
		var bound_systems := entity.get_meta("$" + query_name) as Array
		var binds := entity.get_meta("#" + query_name) as Array
		__remove_entity_from_query(query_name, binds)
		entity.remove_from_group(query_name)
		entity.remove_meta("#" + query_name)
		entity.remove_meta("$" + query_name)
		var entity_id := String(entity.get_instance_id())
		for system in bound_systems:
			var system_inst := system.get_meta(entity_id) as Object
			system.remove_meta(entity_id)
			if system_inst.get_meta(_SYSTEM_INSTANCE, false):
				system_inst.call_deferred("free")
		__array_erase_deferred(bound_queries, query_name);
		bound_queries.erase(query_name)
		bound_systems.clear()


func _init() -> void:
	add_to_group("#q-godot")
	_regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	_tree = get_tree()
	_root = _tree.root


func _ready() -> void:
	yield(_root, "ready")
	_root_ready = true
	__post_change_scene(_tree.current_scene)
