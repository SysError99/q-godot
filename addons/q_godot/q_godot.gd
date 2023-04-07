extends Node


const _BOUND_QUERIES = "_Q"


# Tells if current frame is second frame.
var is_second_frame := false


var _queries := {}


# Query reference.
class Query extends Object:
	var _instance_id := "_%d" % get_instance_id()
	var _parent: Node

	var _parent_class_name := ""
	var _sub_node_paths := []

	var _nodes := []
	var _nodes_first_half := []
	var _nodes_second_half := []
	var _subscribed_systems := [] 

	var _half_query_enabled := false


	func _init(parent: Node, main_node_class_name: String, sub_node_paths: Array) -> void:
		_parent = parent
		_parent_class_name = main_node_class_name
		_sub_node_paths = sub_node_paths


	func __add_node(node: Node, bound_queries: Array) -> void:
		var binds := { "self": node }
		var sub_node: Node
		for sub_node_path in _sub_node_paths:
			if sub_node_path[0] == "-":
				sub_node_path = sub_node_path.substr(1, sub_node_path.length())
				if not node.is_in_group(sub_node_path):
					continue
				sub_node = node.get_node_or_null(sub_node_path)
				if not is_instance_valid(sub_node):
					continue
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
		var i := 0
		var system_binds: Array
		while i < _subscribed_systems.size():
			system_binds = _subscribed_systems[i]
			if not is_instance_valid(system_binds[0]):
##				_subscribed_systems.remove_at(i)
				_subscribed_systems.remove(i)
				continue
			__system_handle(binds, system_binds[0], system_binds[1])
			i += 1
		node.set_meta(_instance_id, binds)
		bound_queries.push_back(self)
		_nodes.push_back(binds)
	

	func __verify_node(node: Node, bound_queries: Array) -> void:
		if node.has_meta(_instance_id):
			for sub_node_path in _sub_node_paths:
				if sub_node_path[0] == "-":
					sub_node_path = sub_node_path.substr(1, sub_node_path.length())
					if not node.is_in_group(sub_node_path):
						continue
					if not is_instance_valid(node.get_node_or_null(sub_node_path)):
						continue
				if node.is_in_group(sub_node_path):
					continue
				elif is_instance_valid(node.get_node_or_null(sub_node_path)):
					continue
				__remove_node(node, bound_queries)
				break


	func __remove_node(node: Node, bound_queries: Array) -> void:
		var binds := node.get_meta(_instance_id) as Dictionary
		__array_erase_deferred(bound_queries, self)
		node.remove_meta(_instance_id)
		_nodes.erase(binds)
		if _half_query_enabled:
			_nodes_first_half.erase(binds)
			_nodes_second_half.erase(binds)


	func __enable_half_query() -> void:
		if _half_query_enabled:
			return
		_half_query_enabled = true
		var size := _nodes.size()
		var half_size := size / 2
		_nodes_first_half = _nodes.slice(0, half_size - 1)
		if size > 1:
			_nodes_second_half = _nodes.slice(half_size, size)


	func __subscribe(system: Object, shared = null) -> void:
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
##			main_node.tree_exiting.connect(func(): system_inst.queue_free())
			main_node.connect("tree_exiting", system_inst, "queue_free")
			main_node.add_child(system_inst)
		else:
			system.callv(shared, binds.values())


	func __array_erase_deferred(array: Array, element) -> void:
##		await _parent.get_tree().process_frame
		yield(_parent.get_tree(), "idle_frame")
		array.erase(element)


	# Half-iterate nodes in the query.
	func half_iterate() -> Array:
		return _nodes_second_half if _parent.get("is_second_frame") else _nodes_first_half


	# Return current amount of nodes inside this query.
	func size() -> int:
		return _nodes.size()


# Bind a query to an instantiable object or instantiated object. If you bind a query to instantiated object, `shared` parameter will be function name string, or else it will be a shared object. The `main_node_class` can be either `Script` reference (such as defined `class_name` with GDScript) or base class name as `String`.
func bind_query(main_node_class, sub_node_paths: Array = [], system: Object = null, shared = null) -> void:
	__query(main_node_class, sub_node_paths).__subscribe(system, shared)


# Build a query from following parameters. The `main_node_class` can be either `Script` reference (such as defined `class_name` with GDScript) or base class name as `String`.
func query(main_node_class, sub_node_paths: Array = []) -> Array:
	return __query(main_node_class, sub_node_paths)._nodes


# Get a query object from following parameters. The `main_node_class` can be either `Script` reference (such as defined `class_name` with GDScript) or base class name as `String`.
func get_query(main_node_class, sub_node_paths: Array = []) -> Query:
	var query := __query(main_node_class, sub_node_paths)
	query.__enable_half_query()
	return query


# Refresh query on specified node.
func refresh_query_on_node(node: Node) -> void:
	var queries := _queries[__recognise_class_name_from_node(node)] as Dictionary
	var bound_queries := node.get_meta(_BOUND_QUERIES) as Array
	var query: Query
	for old_query in bound_queries:
		old_query.__verify_node(node, bound_queries)
	for query_name in queries:
		query = queries[query_name]
		if query in bound_queries:
			continue
		query.__add_node(node, bound_queries)


# Perform a clean-up in QGodot, very ideal to use before changing between scenes.
func flush() -> void:
	for node in get_tree().get_nodes_in_group(_BOUND_QUERIES):
##		node.tree_exiting.disconnect(_main_node_exiting_tree)
		node.disconnect("tree_exiting", self, "_main_node_exiting_tree")
	for main_node_class_name in _queries:
		var queries := _queries[main_node_class_name] as Dictionary
		for query_name in queries:
			queries[query_name].free()
	_queries.clear()


# Shorthand for `get_tree().get_nodes_in_group()` but will take the first found node.
func get_first_node(group_name: String) -> Node:
	return get_tree().get_nodes_in_group(group_name)[0]


func __query(main_node_class, sub_node_paths: Array) -> Query:
	var main_node_class_name := ("%d" % main_node_class.get_instance_id() if main_node_class is Object else main_node_class) as String
	var query_name := main_node_class_name + "," + ",".join(sub_node_paths)
	var queries = {}
	if main_node_class_name in _queries:
		queries = _queries[main_node_class_name]
		if query_name in queries:
			return queries[query_name]
	else:
		_queries[main_node_class_name] = queries
	var query := Query.new(self, main_node_class_name, sub_node_paths)
	for node in get_tree().get_nodes_in_group("____%s____" % main_node_class_name):
		if not node.is_in_group(_BOUND_QUERIES):
			__main_node_setup(node)
		query.__add_node(node, node.get_meta(_BOUND_QUERIES))
	queries[query_name] = query
	return query


func __recognise_class_name_from_node(node: Node) -> String:
	var node_script := node.get_script() as Script
	return "%d" % node_script.get_instance_id() if node_script else node.get_class()


func __main_node_setup(node: Node) -> Array:
	var bound_queries := []
	node.add_to_group(_BOUND_QUERIES)
	node.set_meta(_BOUND_QUERIES, bound_queries)
##	node.tree_exiting.connect(_main_node_exiting_tree.bindv([ node, bound_queries ]), CONNECT_ONE_SHOT)
	node.connect("tree_exiting", self, "_main_node_exiting_tree", [ node, bound_queries ], CONNECT_ONESHOT)
	return bound_queries


func _enter_tree() -> void:
##	get_tree().node_added.connect(_scene_tree_node_added)
	get_tree().connect("node_added", self, "_scene_tree_node_added")


func _process(_delta: float) -> void:
	is_second_frame = not is_second_frame


func _scene_tree_node_added(node: Node) -> void:
	var main_node_class_name := __recognise_class_name_from_node(node)
	node.add_to_group("____%s____" % main_node_class_name)
	if main_node_class_name in _queries:
##		node.ready.connect(_main_node_ready.bindv([ node, main_node_class_name, __main_node_setup(node) ]), CONNECT_ONE_SHOT)
		node.connect("ready", self, "_main_node_ready", [ node, main_node_class_name, __main_node_setup(node) ], CONNECT_ONESHOT)


func _main_node_ready(node: Node, main_node_class_name: String, bound_queries: Array) -> void:
	var queries := _queries[main_node_class_name] as Dictionary
	for query_name in queries:
		queries[query_name].__add_node(node, bound_queries)


func _main_node_exiting_tree(node: Node, bound_queries: Array) -> void:
	for query in bound_queries:
		query.__remove_node(node, bound_queries)
	node.remove_meta(_BOUND_QUERIES)
