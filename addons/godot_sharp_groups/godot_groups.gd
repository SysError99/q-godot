extends Node
class_name GodotGroups


const COMP_ZERO_ERR = "'component_names' must have at least one member!"


const _COMPONENT = "#C"
const _COMP_NAME = "#CN"
const _REGISTERED_SCENE = "#R"
const _QUERY = "#Q"
const _SHARED_VAR = "#V"
const _SYSTEM_CLASS = "#S"


class Iterator extends Node:
	var subscribed_systems := []


var nogroup_templates := {}
var regex := RegEx.new()
var tree: SceneTree
var templates := {}


onready var root := tree.root


func get_iterator(query_name: String) -> Iterator:
	var iterator := root.get_node_or_null(query_name) as Iterator
	if not is_instance_valid(iterator):
		iterator = Iterator.new()
		iterator.name = query_name
		root.add_child(iterator)
	return iterator


func get_query_name(group_name: String, component_names: Array) -> String:
	var query_name = _QUERY + group_name
	for name in component_names:
		query_name += "_" + name
	return query_name


# API
func bind_query(group_name: String, component_names: Array, system: Object, shared = null) -> void:
	assert(component_names.size() > 0, COMP_ZERO_ERR)
	yield(tree, "idle_frame")
	var registered_scenes := tree.get_nodes_in_group(_REGISTERED_SCENE)
	var query_name := get_query_name(group_name, component_names)
	var iterator := get_iterator(query_name)
	iterator.subscribed_systems.push_back({
		_SYSTEM_CLASS: system,
		_SHARED_VAR: shared,
	})
	if group_name == "":
		nogroup_templates[query_name] = component_names
		for scene_ref in registered_scenes:
			var scene := scene_ref as Node
			for entity in scene.get_children():
				bind_to_iterator(entity, query_name, component_names, iterator)
	else:
		if not templates.has(group_name):
			templates[group_name] = { query_name: component_names, }
		else:
			templates[group_name][query_name] = component_names
		for scene_ref in registered_scenes:
			var scene := scene_ref as Node
			for entity_ref in scene.get_children():
				var entity := entity_ref as Node
				if not entity.is_in_group(group_name):
					continue
				bind_to_iterator(entity, query_name, component_names, iterator)


func bind_to_iterators(entity: Node):
	for query_name in nogroup_templates:	
		bind_to_iterator(entity, query_name, nogroup_templates[query_name], get_iterator(query_name))
	for template_name in templates:
		if not entity.is_in_group(template_name):
			continue
		var template := templates[template_name] as Dictionary
		for query_name in template:
			bind_to_iterator(entity, query_name, template[query_name], get_iterator(query_name))


func bind_to_iterator(entity: Node, query_name: String, component_names: Array, iterator: Iterator) -> void:
	if entity.is_in_group(_REGISTERED_SCENE) or entity.get_class() != component_names[0]:
		return
	var binds := entity.get_meta(query_name, []) as Array
	if binds.size() == 0:
		var children := entity.get_children()
		component_names = component_names.duplicate()
		component_names.remove(0);
		for component_name in component_names:
			for component_ref in children:
				var component := component_ref as Node
				if component.name == component_name:
					var bind_name := regex.sub(component_name, "_$1", true).to_lower()
					component.set_meta(_COMP_NAME, bind_name.substr(1, bind_name.length()))
					children.erase(component)
					binds.push_back(component)
					break
		if binds.size() != component_names.size():
			binds.clear()
			return
	entity.set_meta(query_name, binds)
	for system_ref in iterator.subscribed_systems:
		var ref := system_ref[_SYSTEM_CLASS] as Object
		if not ref.has_method("new"):
			binds = binds.duplicate()
			binds.push_front(entity)
			ref.callv(system_ref[_SHARED_VAR], binds)
			continue
		var system := ref.new() as Object
		if system is Node:
			iterator.add_child(system)
		if "parent" in system:
			system.set("parent", entity)
		if "shared" in system:
			system.set("shared", system_ref[_SHARED_VAR])
		if system.has_method("_create"):
			system.call("_create")
		for component_ref in binds:
			var component := component_ref as Node
			system.set(component.get_meta(_COMP_NAME), component_ref)
			component.connect("tree_exited", self, "_entity_component_removed", [ component_ref, system, binds ], CONNECT_ONESHOT)
			if not component.is_in_group(_COMPONENT):
				component.add_to_group(_COMPONENT)
				if system is Node:
					system.add_to_group(query_name)


# API
func query(group_name: String, component_names: Array) -> Array:
	assert(component_names.size() > 0, COMP_ZERO_ERR)
	return tree.get_nodes_in_group(get_query_name(group_name, component_names))


# API
func change_scene(path: String) -> void:
	var current_scene := tree.current_scene
	var inst := (load(path) as PackedScene).instance()
	if is_instance_valid(current_scene):
		current_scene.queue_free()
	register_as_scene(inst);
	root.add_child(inst);


# API
func register_as_scene(node: Node) -> void:
	node.add_to_group(_REGISTERED_SCENE)
	node.connect("child_entered_tree", self, "_entity_entered_tree")


func _entity_entered_tree(entity: Node) -> void:
	yield(entity, "ready")
	entity.connect("child_entered_tree", self, "_entity_component_added", [ entity ])
	bind_to_iterators(entity)


func _entity_exiting_tree(entity: Node) -> void:
	for component_ref in entity.get_children():
		var component := component_ref as Node
		component.emit_signal("tree_exited")


func _entity_component_added(_new_component: Node, entity) -> void:
	_entity_exiting_tree(entity)
	bind_to_iterators(entity)


func _entity_component_removed(component: Node, binder: Object, binds: Array) -> void:
	if component.is_in_group(_COMPONENT):
		component.remove_from_group(_COMPONENT)
	if is_instance_valid(binder):
		binds.clear()
		binder.free()


func _init() -> void:
	regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	tree = get_tree()
	register_as_scene(tree.current_scene)
