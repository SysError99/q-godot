extends Node


const _COMP_ZERO_ERR = "'component_names' must have at least one member!"


const _BOUND_QUERIES = "#boundQueriesQN"
const _COMP_NAME = "#CN"
const _ITERATOR = "#I"
const _REGISTERED_SCENE = "#RS"
const _QUERY = "#Q"
const _QUERY_NODES := "#QN"
const _SHARED_VAR = 1
const _SYSTEM_CLASS = 0
const _SYSTEM_BASE_CLASS = "#BC"
const _UNREGISTERED_SCENE = "registered_scene"


class Query extends Node:
	var component_names := []
	var current_scene_subscribers := []
	var subscribers := []
	func _init() -> void:
		add_to_group(_ITERATOR)
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


var _query_cache := {}
var _query_half_cache := {}
var _regex := RegEx.new()
var _root_ready := false
var _root: Viewport
var _tree: SceneTree


func __get_query_name(component_names: Array) -> String:
	return _QUERY + "_" + PoolStringArray(component_names).join("_")


# API
func bind_query(component_names: Array, system: Object = null, shared = null, to_current_scene: bool = false) -> void:
	if not _root_ready:
		yield(_root, "ready")
	assert(component_names.size() > 0, _COMP_ZERO_ERR)
	var registered_scenes := _tree.get_nodes_in_group(_REGISTERED_SCENE)
	var query_name := __get_query_name(component_names)
	var query_node := _root.get_node_or_null(query_name) as Query
	var subscribers := []
	if not is_instance_valid(query_node):
		query_node = Query.new()
		query_node.name = query_name
		query_node.component_names = component_names
		query_node.add_to_group(_QUERY_NODES)
		_root.add_child(query_node)
	if is_instance_valid(system):
		var new_subscriber := [system, shared]
		query_node.subscribers.push_back(new_subscriber)
		if to_current_scene:
			query_node.current_scene_subscribers.push_back(new_subscriber)
		subscribers = [ new_subscriber ]
	for scene_ref in registered_scenes:
		var scene := scene_ref as Node
		for entity in scene.get_children():
			if entity.is_in_group(_REGISTERED_SCENE):
				continue
			__bind_to_query_node(entity, query_node, subscribers)


# API
func bind_query_to_current_scene(component_names: Array, system: Object = null, shared = null) -> void:
	bind_query(component_names, system, shared, true)


func __bind_to_query_nodes(entity: Node):
	for query_node in _tree.get_nodes_in_group(_QUERY_NODES):
		__bind_to_query_node(entity, query_node, query_node.subscribers)


func __bind_to_query_node(entity: Node, query_node: Query, subscribers: Array) -> void:
	var query_name := query_node.name
	var component_names := query_node.component_names
	if entity.get_class() != component_names[0]:
		return
	var binds := entity.get_meta(query_name + "#", []) as Array
	var bound_queries := entity.get_meta(_BOUND_QUERIES, []) as Array
	var system_instances := entity.get_meta(query_name + "$", []) as Array
	if not query_name in bound_queries:
		component_names = component_names.duplicate()
		component_names.remove(0)
		var number_of_groups := 0
		for component_name in component_names:
			if entity.is_in_group(component_name):
				number_of_groups += 1
				continue
			var component := entity.get_node_or_null(component_name) as Node
			if not is_instance_valid(component):
				break
			entity.set_meta("$" + component_name, component)
			binds.push_back(component)
			if not component.is_connected("tree_exited", self, "_entity_component_removed"):
				component.connect("tree_exited", self, "_entity_component_removed", [ entity, component.name, bound_queries], CONNECT_ONESHOT)
		if binds.size() == component_names.size() - number_of_groups:
			entity.add_to_group(query_name)
			entity.set_meta(query_name + "#", binds)
			entity.set_meta(query_name + "$", system_instances)
			entity.set_meta(_BOUND_QUERIES, bound_queries)
			bound_queries.push_back(query_name)
			if query_name in _query_cache:
				var cache := _query_cache[query_name] as Array
				cache.push_back(entity)
				if query_name in _query_half_cache:
					var half_cache := _query_half_cache[query_name] as HalfQueryReference
					if cache.size() % 2 == 0:
						half_cache.second_half.push_back(entity)
					else:
						half_cache.first_half.push_back(entity)
	var system_instance_name := entity.name + query_name
	for system_ref in subscribers:
		var system := system_ref[_SYSTEM_CLASS] as Object
		if system.has_meta(system_instance_name):
			continue
		system_instances.push_back(system)
		if system.has_method("new"):
			var system_inst := system.new() as Object
			system_inst.set("parent", entity)
			system_inst.set("shared", system_ref[_SHARED_VAR])
			for component in binds:
				var bind_name := _regex.sub(component.name, "_$1", true).to_lower()
				system_inst.set(bind_name.substr(1, bind_name.length()), component)
			system.set_meta(system_instance_name, system_inst)
			query_node.add_child(system_inst)
		else:
			binds = binds.duplicate()
			binds.push_front(entity)
			system.callv(system_ref[_SHARED_VAR], binds)
			system.set_meta(system_instance_name, system)


# API
func query(component_names: Array) -> Array:
	var query_name := __get_query_name(component_names)
	if not query_name in _query_cache:
		if not is_instance_valid(_root.get_node_or_null(query_name)):
			bind_query(component_names)
		_query_cache[query_name] = _tree.get_nodes_in_group(query_name)
	return _query_cache[query_name]


# API
func query_half(component_names: Array) -> HalfQueryReference:
	var query_name := __get_query_name(component_names)
	if  query_name in _query_half_cache:
		return _query_half_cache[query_name]
	var q := HalfQueryReference.new()
	var query := query(component_names)
	var query_size := query.size()
	var query_half_size := query_size / 2
	q.first_half = query.slice(0, query_half_size - 1)
	if query_size > 1:
		q.second_half = query.slice(query_half_size, query.size())
	_query_half_cache[query_name] = q
	return q


# API
func change_scene(path: String) -> void:
	var current_scene := _tree.current_scene
	var inst := (load(path) as PackedScene).instance()
	for query_node in _tree.get_nodes_in_group(_ITERATOR):
		query_node.call("remove_current_scene_subscribers")
	current_scene.queue_free()
	yield(current_scene, "tree_exited")
	_root.set_meta("current_scene", inst)
	_root.call_deferred("add_child", inst)
	_tree.set_deferred("current_scene", inst)
	yield(inst, "ready")
	__post_change_scene(inst)


func __post_change_scene(current_scene: Node) -> void:
	var registered_scenes := _tree.get_nodes_in_group(_UNREGISTERED_SCENE)
	if registered_scenes.size() > 0:
		for scn_ref in registered_scenes:
			var scn := scn_ref as Node
			scn.remove_from_group(_UNREGISTERED_SCENE)
			register_as_scene(scn)
	else:
		register_as_scene(current_scene)


# API
func register_as_scene(node: Node) -> void:
	node.add_to_group(_REGISTERED_SCENE)
	node.connect("child_entered_tree", self, "_entity_entered_scene")
	for child_ref in node.get_children():
		__register_entity(child_ref)


func __register_entity(entity: Node) -> void:
	entity.connect("child_entered_tree", self, "_entity_component_added", [ entity ])
	__bind_to_query_nodes(entity)


func _entity_entered_scene(entity: Node) -> void:
	yield(entity, "ready")
	__register_entity(entity)


func _entity_component_added(_new_component: Node, entity) -> void:
	__bind_to_query_nodes(entity)


func _entity_component_removed(entity: Node, component_name: String, bound_queries: Array) -> void:
	entity.remove_meta("$" + component_name)
	for query_name in bound_queries:
		if not component_name in query_name:
			continue
		var system_instances := entity.get_meta(query_name + "$", []) as Array
		entity.remove_from_group(query_name)
		entity.remove_meta(query_name + "#")
		entity.remove_meta(query_name + "$")
		if query_name in _query_cache:
			var cache := _query_cache[query_name] as Array
			cache.erase(entity)
			if query_name in _query_half_cache:
				var half_cache := _query_half_cache[query_name] as HalfQueryReference
				half_cache.first_half.erase(entity)
				half_cache.second_half.erase(entity)
		var system_instance_name := entity.name + query_name as String
		for system in system_instances:
			if not system.has_meta(system_instance_name):
				continue
			var system_inst := system.get_meta(system_instance_name) as Object
			system.remove_meta(system_instance_name)
			if is_instance_valid(system_inst) and system_inst != system:
				system_inst.call_deferred("free")
		__array_erase_deferred(bound_queries, query_name);
		system_instances.clear()


func __array_erase_deferred(array: Array, element) -> void:
	yield(_tree, "idle_frame")
	array.erase(element)


func _init() -> void:
	_regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	_tree = get_tree()
	_root = _tree.root


func _ready() -> void:
	yield(_root, "ready")
	_root_ready = true
	__post_change_scene(_tree.current_scene)
