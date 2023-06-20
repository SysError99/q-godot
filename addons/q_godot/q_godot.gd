extends Node


const _BOUND_QUERIES = "_Q"
const _QGODOT = "_QGODOT"


# Tells if current frame is second frame.
var is_second_frame := false


var _queries := {}
var _zero_param_signals := []
# List of awaiting signals, 
# { [signal_name]: {"object": Object, "signal_function": String, "signal_binds": Array, "signal_flags": int, "signal_callable": Callable}[] }
var _signal_awaiting_objects := {}
var _signal_awaiting_awaiters := {}


# Query reference.
class Query extends Object:
	var by_name := {}

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
				_subscribed_systems.remove(i)
##				_subscribed_systems.remove_at(i)
				continue
			__system_handle(binds, system_binds[0], system_binds[1])
			i += 1
		node.set_meta(_instance_id, binds)
		bound_queries.push_back(self)
		_nodes.push_back(binds)
		by_name[node.name] = binds


	func __verify_node(node: Node, bound_queries: Array) -> void:
		if node.has_meta(_instance_id):
			if not node.name in by_name:
				for node_name in by_name:
					if by_name[node_name]["self"] == node:
						by_name.erase(node_name)
						break
				by_name[node.name] = node
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
		by_name.erase(node.name)
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
			main_node.connect("tree_exiting", system_inst, "queue_free")
##			main_node.tree_exiting.connect(func(): system_inst.queue_free())
			main_node.add_child(system_inst)
		else:
			system.callv(shared, binds.values())


	func __array_erase_deferred(array: Array, element) -> void:
		yield(_parent.get_tree(), "idle_frame")
##		await _parent.get_tree().process_frame
		array.erase(element)


	# Iterate all nodes in this query.
	func iterate() -> Array:
		return _nodes


	# Half-iterate nodes in the query.
	func half_iterate() -> Array:
		return _nodes_second_half if _parent.get("is_second_frame") else _nodes_first_half


	# Return current amount of nodes inside this query.
	func size() -> int:
		return _nodes.size()


class SignalAwaiter extends Object:
	signal completed(result)
	func _completed(result) -> void:
		emit_signal("completed", result)
##		completed.emit(result)
		call_deferred("free")
	func _completed_() -> void:
		emit_signal("completed", null)
##		completed.emit(null)
		call_deferred("free")


class System extends Node:
	var __: Node

	# Tells if current frame is second frame.
	func is_second_frame() -> bool:
		return __.get("is_second_frame")


	func _init() -> void:
		connect("tree_entered", self, "_tree_entered")


	func _tree_entered() -> void:
		__ = get_tree().get_meta(_QGODOT)


	# Bind a query to an instantiable object or instantiated object. If you bind a query to instantiated object, `shared` parameter will be function name string, or else it will be a shared object. The `main_node_class` can be either `Script` reference (such as defined `class_name` with GDScript) or base class name as `String`.
	func bind_query(main_node_class, sub_node_paths: Array = [], system: Object = null, shared = null) -> void:
		__.call("bind_query", main_node_class, sub_node_paths, system, shared)

	
	# Build a query from following parameters. The `main_node_class` can be either `Script` reference (such as defined `class_name` with GDScript) or base class name as `String`.
	func query(main_node_class, sub_node_paths: Array = []) -> Array:
		return __.call("query", main_node_class, sub_node_paths)


	# Get a query object from following parameters. The `main_node_class` can be either `Script` reference (such as defined `class_name` with GDScript) or base class name as `String`.
	func get_query(main_node_class, sub_node_paths: Array = []) -> Query:
		return __.call("get_query", main_node_class, sub_node_paths)
	
	
	# Refresh query on specified node.
	func refresh_query_on_node(node: Node) -> void:
		__.call("refresh_query_on_node", node)
	
	
	# Perform a clean-up in QGodot, very ideal to use before changing between scenes.
	func flush() -> void:
		__.call("flush")
	
	
	# Shorthand for `get_tree().get_nodes_in_group()` but will take the first found node.
	func get_first_node(group_name: String) -> Node:
		return __.call("get_first_node", group_name)
	
	
	# Create an awaiter for the target signal. You must `yield()` for the `completed` signal. Note that return value must only have one parameter or the awaiter will fail!.
	func to_signal(signal_name: String) -> SignalAwaiter:
		return __.call("to_signal", signal_name)


	# Connect to specified signal safely. If the signal doesn't exist, await until other nodes create it.
	func signal_connect(signal_name: String, target_object: Object, function_name: String, binds = [], flags = 0) -> void:
	##func signal_connect(signal_name: String, callable: Callable, flags = 0) -> void:
		__.call("signal_connect", signal_name, target_object, function_name, binds, flags)
	

	# Disconnect to specified signal safely. If the signal doesn't exist but there is the target node in the awaiting list, remove it from the list.
	func signal_disconnect(signal_name: String, target: Object, function_name: String) -> void:
	##func signal_disconnect(signal_name: String, callable: Callable) -> void:
		__.call("signal_disconnect", signal_name, target, function_name)
	
	
	# Safely fires signal, if the signal doesn't exist, it will create a new one.
	func signal_emit(signal_name: String, args_array: Array = []) -> void:
		__.call("signal_emit", signal_name, args_array)


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
	for main_node_class_name in __recognise_class_names_from_node(node):
		var queries := _queries[main_node_class_name] as Dictionary
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
		node.disconnect("tree_exiting", self, "_main_node_exiting_tree")
##		node.tree_exiting.disconnect(_main_node_exiting_tree)
	for main_node_class_name in _queries:
		var queries := _queries[main_node_class_name] as Dictionary
		for query_name in queries:
			queries[query_name].free()
	_queries.clear()


# Shorthand for `get_tree().get_nodes_in_group()` but will take the first found node.
func get_first_node(group_name: String) -> Node:
	return get_tree().get_nodes_in_group(group_name)[0]


# Create an awaiter for the target signal. You must `yield()` for the `completed` signal. Note that return value must only have one parameter or the awaiter will fail!.
func to_signal(signal_name: String) -> SignalAwaiter:
	var awaiter := SignalAwaiter.new()
	if not has_signal(signal_name):
		if not signal_name in _signal_awaiting_awaiters:
			_signal_awaiting_awaiters[signal_name] = []
		_signal_awaiting_awaiters[signal_name].push_back(awaiter)
		return awaiter
	connect(signal_name, awaiter, "_completed_" if signal_name in _zero_param_signals else "_completed")
##	connect(signal_name, awaiter._completed_ if signal_name in _zero_param_signals else awaiter._completed)
	return awaiter


# Connect to specified signal safely. If the signal doesn't exist, await until other nodes create it.
func signal_connect(signal_name: String, target_object: Object, function_name: String, binds = [], flags = 0) -> void:
##func signal_connect(signal_name: String, callable: Callable, flags = 0) -> void:
	if not has_signal(signal_name):
		if not signal_name in _signal_awaiting_objects:
			_signal_awaiting_objects[signal_name] = []
		for awaiting_object in _signal_awaiting_objects[signal_name]:
			if awaiting_object["target"] == target_object and awaiting_object["function"] == function_name:
##			if awaiting_object["signal_callable"] == callable:
				printerr("'%s' already got pre-connected with '%s::%s'" % [signal_name, awaiting_object["target"], awaiting_object["function"]])
##				printerr("Callble '%s' already bound with signal %s" % [awaiting_object["signal_callable"].get_method(), signal_name])
				return
		_signal_awaiting_objects[signal_name].push_back({ target = target_object, function = function_name, signal_binds = binds, signal_flags = flags })
##		_signal_awaiting_objects[signal_name].push_back({ signal_callable = callable, signal_flags = flags })
		return
	connect(signal_name, target_object, function_name, binds, flags)
##	connect(signal_name, callable, flags)


# Disconnect to specified signal safely. If the signal doesn't exist but there is the target node in the awaiting list, remove it from the list.
func signal_disconnect(signal_name: String, target: Object, function_name: String) -> void:
##func signal_disconnect(signal_name: String, callable: Callable) -> void:
	if has_signal(signal_name):
		disconnect(signal_name, target, function_name)
##		disconnect(signal_name, callable)
	elif signal_name in _signal_awaiting_objects:
		var awaiting_objects := _signal_awaiting_objects[signal_name] as Array
		var i := 0
		while i < awaiting_objects.size():
			var awaiting_object := awaiting_objects[i] as Dictionary
			if awaiting_object["target"] == target:
##			if awaiting_object["signal_callable"] == callable:
				awaiting_objects.remove(i)
##				awaiting_objects.remove_at(i)
				continue
			i += 1


# Safely fires signal, if the signal doesn't exist, it will create a new one.
func signal_emit(signal_name: String, args_array: Array = []) -> void:
	if not has_signal(signal_name):
		var args := []
		var awaiter_exists := false
		for i in args_array.size():
			args.push_back({ name = "arg_%d" % i , type = TYPE_MAX, })
		add_user_signal(signal_name, args)
		if signal_name in _signal_awaiting_awaiters:
			awaiter_exists = true
			match args_array.size():
				0:
					_zero_param_signals.push_back(signal_name)
					for awaiter in _signal_awaiting_awaiters[signal_name]:
						connect(signal_name, awaiter, "_completed_")
##						connect(signal_name, awaiter._completed_)
				1:
					for awaiter in _signal_awaiting_awaiters[signal_name]:
						connect(signal_name, awaiter, "_completed")
##						connect(signal_name, awaiter._completed)
			_signal_awaiting_awaiters.erase(signal_name)
		if signal_name in _signal_awaiting_objects:
			awaiter_exists = true
			for awaiting_object in _signal_awaiting_objects[signal_name]:
				connect(signal_name, awaiting_object["target"], awaiting_object["function"], awaiting_object["signal_binds"], awaiting_object["signal_flags"])
##				connect(signal_name, awaiting_object["signal_callable"], awaiting_object["signal_flags"])
			_signal_awaiting_objects.erase(signal_name)
		if not awaiter_exists:
			printerr("Signal '%s' emitted but no awaiters exist. Have a check if any of connected nodes have 'signal_connect' in proper place (ideally, in '_enter_tree' block)." % signal_name)
	callv("emit_signal", [ signal_name ] + args_array)


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


func __recognise_class_names_from_node(node: Node) -> Array:
	var node_script := node.get_script() as Script
	if node_script:
		return [ "%d" % node_script.get_instance_id(), node.get_class() ]
	return [ node.get_class() ]


func __main_node_setup(node: Node) -> Array:
	var bound_queries := []
	node.add_to_group(_BOUND_QUERIES)
	node.set_meta(_BOUND_QUERIES, bound_queries)
	node.connect("tree_exiting", self, "_main_node_exiting_tree", [ node, bound_queries ], CONNECT_ONESHOT)
##	node.tree_exiting.connect(_main_node_exiting_tree.bindv([ node, bound_queries ]), CONNECT_ONE_SHOT)
	return bound_queries


func _enter_tree() -> void:
	get_tree().set_meta(_QGODOT, self)
	get_tree().connect("node_added", self, "_scene_tree_node_added")
##	get_tree().node_added.connect(_scene_tree_node_added)


func _process(_delta: float) -> void:
	is_second_frame = not is_second_frame


func _scene_tree_node_added(node: Node) -> void:
	for main_node_class_name in __recognise_class_names_from_node(node):
		node.add_to_group("____%s____" % main_node_class_name)
		if main_node_class_name in _queries:
			node.connect("ready", self, "_main_node_ready", [ node, main_node_class_name, __main_node_setup(node) ], CONNECT_ONESHOT)
##			node.ready.connect(_main_node_ready.bindv([ node, main_node_class_name, __main_node_setup(node) ]), CONNECT_ONE_SHOT)


func _main_node_ready(node: Node, main_node_class_name: String, bound_queries: Array) -> void:
	var queries := _queries[main_node_class_name] as Dictionary
	for query_name in queries:
		queries[query_name].__add_node(node, bound_queries)


func _main_node_exiting_tree(node: Node, bound_queries: Array) -> void:
	for query in bound_queries:
		query.__remove_node(node, bound_queries)
	node.remove_meta(_BOUND_QUERIES)
