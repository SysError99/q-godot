extends Node


const _COMP_ZERO_ERR = "'component_names' must have at least one member!"


const _COMP_NAME = "#CN"
const _ITERATOR = "#I"
const _REGISTERED_SCENE = "#RS"
const _QUERY = "#Q"
const _QUERY_NAMES = "#QN"
const _SHARED_VAR = 1
const _SYSTEM_CLASS = 0
const _SYSTEM_BASE_CLASS = "#BC"
const _UNREGISTERED_SCENE = "registered_scene"


class Iterator extends Node:
	var current_scene_subscribers := []
	var subscribers := []
	func _init() -> void:
		add_to_group(_ITERATOR)
	func remove_current_scene_subscribers() -> void:
		for element in current_scene_subscribers:
			subscribers.erase(element)
		current_scene_subscribers.clear()


var _query_cache := {}
var _regex := RegEx.new()
var _root_ready := false
var _root: Viewport
var _templates := {}
var _tree: SceneTree


func __get_iterator(query_name: String) -> Iterator:
	var iterator := _root.get_node_or_null(query_name) as Iterator
	if not is_instance_valid(iterator):
		iterator = Iterator.new()
		iterator.name = query_name
		_root.add_child(iterator)
	return iterator


func __get_query_name(component_names: Array) -> String:
	return _QUERY + "_" + PoolStringArray(component_names).join("_")


# API
func bind_query(component_names: Array, system: Object, shared = null, to_current_scene: bool = false) -> void:
	if not _root_ready:
		yield(_root, "ready")
	assert(component_names.size() > 0, _COMP_ZERO_ERR)
	var query_name := __get_query_name(component_names)
	var iterator := __get_iterator(query_name)
	var new_subscriber := [system, shared]
	iterator.subscribers.push_back(new_subscriber)
	if to_current_scene:
		iterator.current_scene_subscribers.push_back(new_subscriber)
	__build_query(query_name, component_names, iterator, [new_subscriber])


# API
func bind_query_to_current_scene(component_names: Array, system: Object, shared = null) -> void:
	bind_query(component_names, system, shared, true)


func __build_query(query_name: String, component_names: Array, iterator: Object, subscribers: Array) -> void:
	var registered_scenes := _tree.get_nodes_in_group(_REGISTERED_SCENE)
	_templates[query_name] = component_names
	for scene_ref in registered_scenes:
		var scene := scene_ref as Node
		for entity in scene.get_children():
			if entity.is_in_group(_REGISTERED_SCENE):
				continue
			__bind_to_iterator(entity, query_name, component_names, iterator, subscribers)


func __bind_to_iterators(entity: Node):
	for query_name in _templates:
		var iterator := __get_iterator(query_name)
		__bind_to_iterator(entity, query_name, _templates[query_name], iterator, iterator.subscribers)


func __bind_to_iterator(entity: Node, query_name: String, component_names: Array, iterator: Iterator, subscribers: Array) -> void:
	if entity.get_class() != component_names[0]:
		return
	var binds := entity.get_meta(query_name + "#", []) as Array
	var systems := entity.get_meta(query_name + "$", []) as Array
	var query_names := entity.get_meta(_QUERY_NAMES, []) as Array
	if not query_name in query_names:
		component_names = component_names.duplicate()
		component_names.remove(0)
		var number_of_groups := 0
		for component_name in component_names:
			if entity.is_in_group(component_name):
				number_of_groups += 1
				continue
			var component := entity.get_node_or_null(component_name) as Node
			if not is_instance_valid(component):
				return
			entity.set_meta("$" + component_name, component)
			binds.push_back(component)
			if not component.is_connected("tree_exited", self, "_entity_component_removed"):
				component.connect("tree_exited", self, "_entity_component_removed", [ entity, component, query_names], CONNECT_ONESHOT)
		if binds.size() == component_names.size() - number_of_groups:
			entity.add_to_group(query_name)
			entity.set_meta(query_name + "#", binds)
			entity.set_meta(query_name + "$", systems)
			entity.set_meta(_QUERY_NAMES, query_names)
			query_names.push_back(query_name)
			if query_name in _query_cache:
				var cache := _query_cache[query_name] as Array
				cache.push_back(entity)
	var system_inst_name := entity.name + query_name
	for system_ref in subscribers:
		var system := system_ref[_SYSTEM_CLASS] as Object
		if system.has_meta(system_inst_name):
			continue
		if system.has_method("new"):
			system = system.new()
			system.set("parent", entity)
			system.set("shared", system_ref[_SHARED_VAR])
			for component in binds:
				var bind_name := _regex.sub(component.name, "_$1", true).to_lower()
				system.set(bind_name.substr(1, bind_name.length()), component)
			iterator.add_child(system)
		else:
			binds = binds.duplicate()
			binds.push_front(entity)
			systems.push_back(system)
			system.callv(system_ref[_SHARED_VAR], binds)
		system.set_meta(system_inst_name, system)


# API
func query(component_names: Array) -> Array:
	var query_name := __get_query_name(component_names)
	if not query_name in _query_cache:
		if not query_name in _templates:
			__build_query(query_name, component_names, __get_iterator(query_name), [])
		_query_cache[query_name] = _tree.get_nodes_in_group(query_name)
	return _query_cache[query_name]


# API
func change_scene(path: String) -> void:
	var inst := (load(path) as PackedScene).instance()
	for iterator in _tree.get_nodes_in_group(_ITERATOR):
		iterator.call("remove_current_scene_subscribers")
	_tree.current_scene.queue_free()
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
	node.connect("child_exiting_tree", self, "_entity_exiting_scene")
	for child_ref in node.get_children():
		__register_entity(child_ref)


func __register_entity(entity: Node) -> void:
	entity.connect("child_entered_tree", self, "_entity_component_added", [ entity ])
	__bind_to_iterators(entity)


func _entity_entered_scene(entity: Node) -> void:
	yield(entity, "ready")
	__register_entity(entity)


func _entity_exiting_scene(entity: Node) -> void:
	for component_ref in entity.get_children():
		var component := component_ref as Node
		component.emit_signal("tree_exited")


func _entity_component_added(_new_component: Node, entity) -> void:
	__bind_to_iterators(entity)


func _entity_component_removed(entity: Node, component: Node, query_names: Array) -> void:
	var component_name := component.name
	entity.remove_meta("$" + component_name)
	for query_name in query_names:
		if not component_name in query_name:
			continue
		var system_inst_name := entity.name + query_name as String
		var systems := entity.get_meta(query_name + "$", []) as Array
		entity.remove_meta(query_name + "#")
		entity.remove_meta(query_name + "$")
		entity.remove_from_group(query_name)
		if query_name in _query_cache:
			var cache := _query_cache[query_name] as Array
			cache.erase(entity)
		for system in systems:
			if not system.has_meta(system_inst_name):
				continue
			var system_inst := system.get_meta(system_inst_name) as Object
			system.remove_meta(system_inst_name)
			if is_instance_valid(system_inst) and system_inst != system:
				system_inst.call_deferred("free")
		systems.clear()


func _init() -> void:
	_regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	_tree = get_tree()
	_root = _tree.root


func _ready() -> void:
	yield(_root, "ready")
	_root_ready = true
	__post_change_scene(_tree.current_scene)
