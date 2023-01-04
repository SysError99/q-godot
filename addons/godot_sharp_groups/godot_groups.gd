extends Node
class_name GodotGroups


const COMP_ZERO_ERR = "'component_names' must have at least one member!"


const _COMP_NAME = "#CN"
const _REGISTERED_SCENE = "#R"
const _QUERY = "#Q"
const _SHARED_VAR = 1
const _SYSTEM_CLASS = 0


class Iterator extends Node:
	var subscribed_systems := []


class QueryYielder extends Object:
	signal completed(array)


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
	assert(system.has_method("new"), "'system' requires 'new()' in order to instantiate!")
	assert(component_names.size() > 0, COMP_ZERO_ERR)
	yield(tree, "idle_frame")
	var query_name := get_query_name(group_name, component_names)
	var iterator := get_iterator(query_name)
	iterator.subscribed_systems.push_back([system, shared])
	build_query(group_name, query_name, component_names, iterator)
	

func build_query(group_name: String, query_name: String, component_names: Array, iterator: Object, dry_run = false) -> void:
	var registered_scenes := tree.get_nodes_in_group(_REGISTERED_SCENE)
	if group_name == "":
		nogroup_templates[query_name] = component_names
		for scene_ref in registered_scenes:
			var scene := scene_ref as Node
			for entity in scene.get_children():
				bind_to_iterator(entity, query_name, component_names, iterator, dry_run)
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
				bind_to_iterator(entity, query_name, component_names, iterator, dry_run)


func bind_to_iterators(entity: Node):
	for query_name in nogroup_templates:
		bind_to_iterator(entity, query_name, nogroup_templates[query_name], get_iterator(query_name))
	for template_name in templates:
		if not entity.is_in_group(template_name):
			continue
		var template := templates[template_name] as Dictionary
		for query_name in template:
			bind_to_iterator(entity, query_name, template[query_name], get_iterator(query_name))


func bind_to_iterator(entity: Node, query_name: String, component_names: Array, iterator: Iterator, dry_run = false) -> void:
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
			return
	var systems := []
	entity.add_to_group(query_name)
	entity.set_meta(query_name, binds)
	if dry_run:
		return
	for system_ref in iterator.subscribed_systems:
		var system := system_ref[_SYSTEM_CLASS].new() as Object
		systems.push_back(system)
		system.set("parent", entity)
		system.set("shared", system_ref[_SHARED_VAR])
		if system is Node:
			iterator.add_child(system)
		if system.has_method("_create"):
			system.call("_create")
		for component_ref in binds:
			var component := component_ref as Node
			system.set(component.get_meta(_COMP_NAME), component_ref)
	for component_ref in binds:
		var component := component_ref as Node
		component.connect("tree_exited", self, "_entity_component_removed", [ entity, query_name, systems ], CONNECT_ONESHOT)


# API
func query(group_name: String, component_names: Array) -> QueryYielder:
	assert(component_names.size() > 0, COMP_ZERO_ERR)
	var yielder := QueryYielder.new()
	_yield_query(group_name, component_names, yielder)
	return yielder


func _yield_query(group_name: String, component_names: Array, yielder: QueryYielder) -> void:
	var query_name := get_query_name(group_name, component_names)
	yield(tree, "idle_frame")
	build_query(group_name, query_name, component_names, get_iterator(query_name))
	var list := []
	for entity in tree.get_nodes_in_group(query_name):
		list.push_back(entity.get_meta(query_name))
	yielder.emit_signal("completed", list)


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


func _entity_component_removed(entity: Node, query_name: String, systems: Array) -> void:
	if systems.size() > 0:
		if entity.has_meta(query_name):
			entity.remove_meta(query_name)
		if entity.is_in_group(query_name):
			entity.remove_from_group(query_name)
		for system in systems:
			if system is Node:
				system.queue_free()
			else:
				system.free()
		systems.clear()


func _init() -> void:
	regex.compile("((?<=[a-z])[A-Z]|[A-Z](?=[a-z])|[0-9])")


func _enter_tree() -> void:
	tree = get_tree()
	register_as_scene(tree.current_scene)
