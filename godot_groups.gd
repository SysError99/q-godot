extends Node
class_name GodotGroups


const _COMPONENT = "__component__"
const _REGISTERED_SCENE = "__registered_scene__"
const _SYSTEM_CLASS = "0"
const _SHARED_VAR = "1"


class Iterator extends Node:
	var subscribed_systems := []


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
	var query_name = "__query__" + group_name + "__"
	for name in component_names:
		query_name += name + "__"
	return query_name


# API
func bind_query(group_name: String, component_names: Array, system: Object, shared = {}) -> void:
	var query_name := get_query_name(group_name, component_names)
	yield(tree, "idle_frame")
	var iterator := get_iterator(query_name)
	iterator.subscribed_systems.push_back({
		_SYSTEM_CLASS: system,
		_SHARED_VAR: shared,
	})
	build_query(group_name, query_name, component_names)


func build_query(group_name: String, query_name: String, component_names: Array) -> void:
	var registered_scenes := tree.get_nodes_in_group(_REGISTERED_SCENE)
	if not templates.has(group_name):
		templates[group_name] = { query_name: component_names, }
	else:
		templates[group_name][query_name] = component_names
	if group_name == "":
		for scene_ref in registered_scenes:
			var scene := scene_ref as Node
			for entity in scene.get_children():
				bind_to_iterator(entity, query_name, component_names)
	else:
		for scene_ref in registered_scenes:
			var scene := scene_ref as Node
			for entity_ref in scene.get_children():
				var entity := entity_ref as Node
				if not entity.is_in_group(group_name):
					continue
				bind_to_iterator(entity, query_name, component_names)


func bind_to_iterators(entity: Node):
	if templates.has(""):
		var template := templates[""] as Dictionary
		for query_name in template:
			bind_to_iterator(entity, query_name, template[query_name])
	for template_name in templates:
		if not entity.is_in_group(template_name):
			continue
		var template := templates[template_name] as Dictionary
		for query_name in template:
			bind_to_iterator(entity, query_name, template[query_name])


func bind_to_iterator(entity: Node, query_name: String, component_names: Array) -> void:
	if entity.is_in_group(_REGISTERED_SCENE):
		return
	if entity.get_class() != component_names[0]:
		return
	var binds := []
	var children := entity.get_children()
	component_names = component_names.duplicate()
	component_names.remove(0);
	for component_name in component_names:
		for component_ref in children:
			var component := component_ref as Node
			if component.name == component_name:
				children.erase(component)
				binds.push_back(component)
				break
	if binds.size() != component_names.size():
		return
	var iterator := get_iterator(query_name)
	for system_ref in iterator.subscribed_systems:
		var system := system_ref[_SYSTEM_CLASS].new() as Object
		if system is Node:
			iterator.add_child(system)
		if "parent" in system:
			system.set("parent", entity)
		if "root" in system:
			system.set("root", root)
		if "shared" in system:
			system.set("shared", system_ref[_SHARED_VAR])
		if system.has_method("_create"):
			system.call("_create")
		for component_ref in binds:
			var component := component_ref as Node
			var bind_name := regex.sub(component.name, "_$1", true).to_lower()
			system.set(bind_name.substr(1, bind_name.length()), component_ref)
			component.connect("tree_exited", self, "_entity_component_removed", [ component_ref, system ], CONNECT_ONESHOT)
			if not component.is_in_group(_COMPONENT):
				component.add_to_group(_COMPONENT)
				if system is Node:
					system.add_to_group(query_name)


# API
func query(group_name: String, component_names: Array) -> Array:
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
		if component.is_in_group(_COMPONENT):
			component.emit_signal("tree_exited")


func _entity_component_added(_new_component: Node, entity) -> void:
	_entity_exiting_tree(entity)
	bind_to_iterators(entity)


func _entity_component_removed(component: Node, binder: Object) -> void:
	if component.is_in_group(_COMPONENT):
		component.remove_from_group(_COMPONENT)
	if is_instance_valid(binder):
		binder.free()


func _init() -> void:
	regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	tree = get_tree()
	register_as_scene(tree.current_scene)
	
