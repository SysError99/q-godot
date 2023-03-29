extends Node


const _BOUND_NODE = "__BN"
const _BOUND_QUERIES = "__BQ"


# (DEPRECATED, will be removed in 1.0) Signal that indicates if query is ready.
signal query_ready()


# Tells if current frame is second frame.
var is_second_frame := false


var _queries := {}


# Query reference.
class Query extends Object:
	var _instance_id := "_" + String(get_instance_id())
	var _parent: Node

	var _parent_class_name := ""
	var _sub_node_paths := []

	var _nodes := []
	var _nodes_first_half := []
	var _nodes_second_half := []
	var _subscribed_systems := [] 

	var _half_query_enabled := false


	func _init(parent: Node, parent_class_name: String, sub_node_paths: Array) -> void:
		_parent = parent
		_parent_class_name = parent_class_name
		_sub_node_paths = sub_node_paths


	func add_node(node: Node, bound_queries: Array) -> void:
		print(node.name)
		var binds := { "self": node }
		var sub_node: Node
		for sub_node_path in _sub_node_paths:
			if node.is_in_group(sub_node_path):
				continue
			sub_node = node.get_node_or_null(sub_node_path)
			if is_instance_valid(sub_node):
				binds[sub_node_path] = sub_node
				continue
			binds.clear()
			return
		if _half_query_enabled:
			if _nodes.size() % 2 == 0:
				_nodes_first_half.push_back(binds)
			else:
				_nodes_second_half.push_back(binds)
		for system_binds in _subscribed_systems:
			__system_handle(binds, system_binds[0], system_binds[1])
		node.set_meta(_instance_id, binds)
		bound_queries.push_back(self)
		_nodes.push_back(binds)
	

	func verify_node(node: Node, bound_queries: Array) -> void:
		if node.has_meta(_instance_id):
			var binds := node.get_meta(_instance_id) as Dictionary
			for sub_node_path in _sub_node_paths:
				if node.is_in_group(sub_node_path):
					continue
				elif is_instance_valid(node.get_node_or_null(sub_node_path)):
					continue
				remove_node(node, bound_queries)
				break


	func remove_node(node: Node, bound_queries: Array) -> void:
		var binds := node.get_meta(_instance_id) as Dictionary
		__array_erase_deferred(bound_queries, self)
		node.remove_meta(_instance_id)
		_nodes.erase(binds)
		if _half_query_enabled:
			_nodes_first_half.erase(binds)
			_nodes_second_half.erase(binds)


	func enable_half_query() -> void:
		_half_query_enabled = true
		var size := _nodes.size()
		var half_size := size / 2
		_nodes_first_half = _nodes.slice(0, half_size - 1)
		if size > 1:
			_nodes_second_half = _nodes.slice(half_size, size)


	func subscribe(system: Object, shared = null) -> void:
		if system in _subscribed_systems:
			return
		for binds in _nodes:
			__system_handle(binds, system, shared)
		_subscribed_systems.push_back([system, shared])
	

	func __system_handle(binds: Dictionary, system: Object, shared) -> void:
		if system.has_method("new"):
			var bind_array := binds.values()
			var main_node := bind_array[0] as Node
			var system_inst := system.callv("new", bind_array) as Node
			system_inst.set("shared", shared)
			main_node.add_child(system_inst)
##			main_node.tree_exiting.connect(func(): system_inst.queue_free())
			main_node.connect("tree_exiting", system_inst, "queue_free")
		else:
			system.callv(shared, binds.values())


	func __array_erase_deferred(array: Array, element) -> void:
##		await _parent().get_tree().process_frame
		yield(_parent.get_tree(), "idle_frame")
		array.erase(element)


	# Half-iterate nodes in the query.
	func iterate() -> Array:
		return _nodes_second_half if _parent.get("is_second_frame") else _nodes_first_half
	
	
	# Return current amount of nodes inside this query.
	func size() -> int:
		return _nodes.size()


# (DEPRECATED, will be removed in 1.0) Class for half query operation. If you use type casting, refer it to `QGodot.Query` instead.
class HalfQueryReference extends Query:
	pass


# Bind a query to an object or an instantiable object. If you bind a query to instantiated object, 'shared' parameter will be function name string.
func bind_query(parent_class_name: String, sub_node_paths: Array = [], system: Object = null, shared = null) -> void:
	__query(parent_class_name, sub_node_paths).subscribe(system, shared)


# Build a query from following parameters.
func query(parent_class_name: String, sub_node_paths: Array = []) -> Array:
	return __query(parent_class_name, sub_node_paths)._nodes


# Obtain a half-iteratable query.
func query_half(parent_class_name: String, sub_node_paths: Array = []) -> Query:
	var query := __query(parent_class_name, sub_node_paths)
	query._half_query_enabled = true
	return query


# Refresh query on specified node.
func refresh_query_on_node(node: Node) -> void:
	var bound_queries := node.get_meta(_BOUND_QUERIES, []) as Array
	var queries := _queries[node.get_class()] as Dictionary
	var query: Query
	for old_query in bound_queries:
		old_query.verify_node(node, bound_queries)
	for query_name in queries:
		query = queries[query_name]
		if query in bound_queries:
			continue
		query.add_node(node, bound_queries)


# Perform massive query nuke in QGodot.
func flush() -> void:
	for node in get_tree().get_nodes_in_group(_BOUND_NODE):
		node.disconnect("tree_exiting", self, "_main_node_exiting_tree")
	for parent_class_name in _queries:
		var queries := _queries[parent_class_name] as Dictionary
		for query_name in queries:
			queries[query_name].free()
	_queries.clear()


# Clean up everything before changing scene, very ideal after finishing QGodot session.
func flush_and_change_scene(path: String) -> void:
	flush()
	get_tree().change_scene(path)


# (DEPRECATED, will be removed in 1.0) Change scene.
func change_scene(path: String) -> void:
	get_tree().change_scene(path)


# (DEPRECATED, will be removed in 1.0) Does nothing, since query is now reworked.
func register_as_scene(node: Node) -> void:
	pass


# (DEPRECATED, will be removed in 1.0) Add specified node to a group, and perform query bindings. Consider adding groups with built-in functions and then use `QGodot.refresh_query_on_node()` on the main node instead.
func add_node_to_group(node: Node, group_name: String) -> void:
	node.add_to_group(group_name)
	refresh_query_on_node(node)


# (DEPRECATED, will be removed in 1.0) Remove specified node to a group, and perform query bindings. Consider removing groups with built-in functions and then use `QGodot.refresh_query_on_node()` on the main node instead.
func remove_node_from_group(node: Node, group_name: String) -> void:
	node.remove_from_group(group_name)
	refresh_query_on_node(node)


# (DEPRECATED, will be removed in 1.0) Rename sub node and preform query bindings. Consider renaming names of sub nodes with built-in functions and then use `QGodot.refresh_query_on_node()` on the main node instead.
func rename_sub_node(sub_node: Node, new_name: String) -> void:
	sub_node.name = new_name
	refresh_query_on_node(__find_main_node(sub_node))


# Depends by 'rename_sub_node()', should be removed in 1.0.
func __find_main_node(sub_node: Node) -> Node:
	var parent := sub_node.get_parent()
	if !sub_node.has_meta(_BOUND_QUERIES):
		return __find_main_node(parent)
	return parent


func __query(parent_class_name: String, sub_node_paths: Array) -> Query:
	var query_name := __get_query_name(parent_class_name, sub_node_paths)
	var queries = {}
	if parent_class_name in _queries:
		queries = _queries[parent_class_name]
	else:
		_queries[parent_class_name] = queries
	if query_name in queries:
		return queries[query_name]
	var query := Query.new(self, parent_class_name, sub_node_paths)
	for node in get_tree().get_nodes_in_group("____%s____" % parent_class_name):
		if node.has_meta(_BOUND_QUERIES):
			query.add_node(node, node.get_meta(_BOUND_QUERIES))
	queries[query_name] = query
	return query


func __get_query_name(parent_class_name: String, sub_node_paths: Array) -> String:
	return parent_class_name + "," + ",".join(sub_node_paths)


func _enter_tree() -> void:
##	get_tree().node_added.connect(_scene_tree_node_added)
	get_tree().connect("node_added", self, "_scene_tree_node_added")
##	get_tree().root.ready.connect(func(): query_ready.emit())
	get_tree().root.connect("ready", self, "emit_signal", [ "query_ready" ])


func _process(delta: float) -> void:
	is_second_frame = not is_second_frame


func _scene_tree_node_added(node: Node) -> void:
	node.add_to_group("____%s____" % node.get_class())
	if node.get_class() in _queries:
		var bound_queries := []
		var params := [ node, bound_queries ]
		node.add_to_group(_BOUND_NODE)
		node.set_meta(_BOUND_QUERIES, bound_queries)
##		node.ready.connect(_main_node_ready.bindv(params), Object.CONNECT_ONESHOT)
		node.connect("ready", self, "_main_node_ready", params, CONNECT_ONESHOT)
##		node.tree_exiting.connect(_main_node_exiting_tree.bindv(params), Object.CONNECT_ONESHOT)
		node.connect("tree_exiting", self, "_main_node_exiting_tree", params, CONNECT_ONESHOT)


func _main_node_ready(node: Node, bound_queries: Array) -> void:
	var queries := _queries[node.get_class()] as Dictionary
	for query_name in queries:
		queries[query_name].add_node(node, bound_queries)


func _main_node_exiting_tree(node: Node, bound_queries: Array) -> void:
	for query in bound_queries:
		query.remove_node(node, bound_queries)
	node.remove_meta(_BOUND_QUERIES)
