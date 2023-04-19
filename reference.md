# API Reference
This provides all functions that QGodot offers.

- [`QGodot` Singleton](#qgodot-singleton)
	- [Querying](#querying)
		- [query(node_name, sub_node_paths): Array](#querynode_name-stringscript-sub_node_paths-arraystring-array)
		- [get_query(node_name, sub_node_paths): Query](#get_querymain_node-stringscript-sub_node_paths-arraystring-query)
		- [bind_query(main_node, sub_node_paths, target, method): void](#bind_querymain_node-stringscript-sub_node_paths-arraystring-target_or_script-object-method_or_shared-stringobject)
		- [bind_query(main_node, sub_node_paths, script, shared): void](#bind_querymain_node-stringscript-sub_node_paths-arraystring-target_or_script-object-method_or_shared-stringobject)
		- [refresh_query_on_node(node): void](#refresh_query_on_nodenode-node-void)
		- [flush(): void](#flush-void)
	- [Global Signals](#global-signals)
		- [signal(signal_name): SignalAwaiter](#signalsignal_name-string-signalawaiter)
		- [signal_emit(signal_name, params): void](#signal_emitsignal_name-string-params-array-void)
		- [signal_connect(signal_name, target, function_name): void](#signal_connectsignal_name-string-target-object-function_name-string-binds---flags--0)
		- [signal_disconnect(signal_name, target, function_name): void](#signal_disconnectsignal_name-string-target-object-function_name-string-void)
	- [Miscellaneous](#miscellaneous)
		- [is_second_frame: bool](#is_second_frame-bool)
		- [get_first_node(group_name): Node](#get_first_nodegroup_name-string-node)
- [Class `Query`](#class-query)
	- [by_name: Dictionary<String, Dictionary>](#by_name-dictionarystring-dictionary)
	- [iterate(): Array](#iterate-array)
	- [half_iterate(): Array](#half_iterate-array)
	- [size(): int](#size-int)

---

## `QGodot` Singleton
This is a main singleton that handles functionality of QGodot.

### Querying
This section contains all of functions related to querying system.

#### `query(node_name: String|Script, sub_node_paths: Array[String]): Array`
This give an array of nodes matching specified main node class names and all node paths.

*There are few syntaxes and features to learn more in this snippet. Take a look at below:*

```gdscript
onready var units := QGodot.query(
	"KinematicBody",
	[
		"Status",
	]
)


onready var mobs := QGodot.query(
	"KinematicBody",
	[
		"Status",
		"Loot",
	]
)


onready var horses := QGodot.query(
	"KinematicBody",
	[
		"Status",
		"Loot",
		"horse", # group name inclusion.
	]
)


onready var wild_horses := QGodot.query(
	"KinematicBody",
	[
		"Status",
		"Loot",
		"-Inventory", # '-' node path exclusion.
		"horse",
	]
)


onready var tamed_horses := QGodot.query(
	"KinematicBody",
	[
		"Status",
		"Loot",
		"Inventory",
		"horse",
	]
)


onready var other_players := QGodot.query(
	Player, # If defined class is a custom class, use defined 'class_name' or 'Script' type of class instances instead.
	"Status",
	"Inventory",
	"-local_player", # group name exclusion
)
```

#### `get_query(main_node: String|Script, sub_node_paths: Array[String]): Query`
This function works the same way as `query()` but instead gives a `Query` instance instead of an array of nodes.

#### `bind_query(main_node: String|Script, sub_node_paths: Array[String], target_or_script: Object, method_or_shared: String|Object)`
This works the same way as `query()` but will bind a callback to target function in the specified instance. When a new node is entered the scene tree, this will fire up and gives all nodes specified in the query in function parameters.

```gdscript
func _ready():
	QGodot.bind_query(
		"StaticBody2D",
		[
			"Sprite",
			"CollsionShape2D",
			"wall", # This is godot group, will not be included in the callback parameter.
		]
	)


func _static_body_entered(main_node: StaticBody, sprite: Sprite, col: CollisionShape2D) -> void: # first parameter will always be main node, and any of node groups won't be included (in this case, 'wall').
	print("%s entered!" % main_node.name)
	sprite.texture = preload("res://icon.png")
```

Alternatively, you can also bind the query with instantiable `Script` that has base type of `Node`. This will increase performance by instantiating node that controls the main node instead.

```gdscript
class PropCarMovementSystem extends Node:
	var shared: Node
	var car: KinematicBody
	var wheels := []
	func _init(main_node, wheel_0, wheel_1, wheel_2, wheel_3):
		car = main_node
		wheels.push_back(wheel_0)
		wheels.push_back(wheel_1)
		wheels.push_back(wheel_2)
		wheels.push_back(wheel_3)
	func _process():
		car.global_translation.z -= 0.1
		for wheel in wheels:
			wheel.rotation.x += 0.1


func _ready():
	QGodot.bind_query(
		"KinematicBody",
		[
			"Wheels/Wheel0",
			"Wheels/Wheel1",
			"Wheels/Wheel2",
			"Wheels/Wheel3",
		],
		PropCarMovementSystem, # use instantiable script instead of instance.
		self # binds with this instance.
	)
```

#### `refresh_query_on_node(node: Node): void`
Performs querying on specified node after its tree structure and grouping alternation.

```gdscript
horse.add_child("Inventory")
horse.add_to_group("uncontrollable")
refresh_query_on_node(horse)
```

#### `flush(): void`
Perform a cleanup (all created queries). Should be used before changing between scenes.

```gdscript
QGodot.flush()
get_tree().change_scene("res://scn/scn_battle_result.tscn")
```

### Global Signals
This section contains functionalites related to QGodot's integrated global signals.

#### `signal(signal_name: String): SignalAwaiter`
Create an awaiter for the target signal. You must `yield()` for the `completed` signal. Note that return value must only have one parameter or the awaiter will fail!.

```gdscript
var input = yield(QGodot.signal("input_prompted"), "completed")
```

Then, to emit a signal:

```gdscript
QGodot.signal_emit("input_prompted", [ 1234 ])
```

#### `signal_emit(signal_name: String, params: Array): void`
Emits a signal. If the signal doesn't exist, create a new one and connects all awaiting lists to the signal.

*CAUTION: DO NOT USE SAME SIGNAL NAME BUT WITH DIFFERENT PARAMETER LENGTH, OR IT WILL RESULT IN UNSUCCESSFUL SIGNAL CREATION AND EMISSION. `flush()` WILL NOT HELP.*

```gdscript
QGodot.emit_signal("unit_killed", [killer, target])
```

#### `signal_connect(signal_name: String, target: Object, function_name: String, binds = [], flags = 0)`
Perform signal connection. If the signal doesn't exist, await until the signal is created then connect to it.

```gdscript
func _ready():
	QGodot.signal_connect("unit_killed", self, "_unit_killed")


func _unit_killed(killer: Spatial, target: Spatial) -> void:
	print("%s killed %s!" % [killer.name, target.name])
```

#### `signal_disconnect(signal_name: String, target: Object, function_name: String): void`
Disconnects a singal from target function. If the signal doesn't exist, remove from await list.

```gdscript
QGodot.signal_disconnect("unit_killed", self, "_unit_killed")
```

### Miscellaneous
Lists that contain other functionalies in QGodot.

#### `is_second_frame: bool`
This determines if this 'process' frame is on second frame. Mainly is used for half-querying process and is very useful if you wanted to sync with half-querying or just wanted to reduce amount of processing in certain nodes.

*CAUTION: DO NOT USE THIS WITH PHYSICS PROCESSES, OR IT COULD PRODUCE UNEXPECTED RESULTS!*

```gdscript
extends KinematicBody2D
class_name Player


func _process(delta):
	if QGodot.is_second_frame:
		return
	# Do something else
```

#### `get_first_node(group_name: String): Node`
Shorthand for `get_tree().get_nodes_in_group()` but will take the first found node.

---

## Class `Query`
An object that holds list of nodes and ways to handle them.

#### `by_name: Dictionary<String, Dictionary>`
This contains all nodes in this query, assigned with names of main nodes.

```gdscript
onready var players := QGodot.get_query("KinematicBody", ["Inventory"])
onready var world := QGodot.get_first_node("world") # Player container.


# Assuming that data is received and passed as Dictionary (mostly is from JSON)
func _data_received(data: Dictionary) -> void:
	var id = data["id"]
	var player: KinematicBody
	if not id in players.by_name:
		## New player.
		player = preload("res://obj/player.tscn").instance()
		player.translation = Vector3(data["x"], data["y"], data["z"])
		player.name = id
		world.add_child(player)
		return
	## Player already exists.
	var binds := players.by_name[id]
	player = binds["self"]
	player.translation = Vector3(data["x"], data["y"], data["z"])
```

#### `iterate(): Array`
Iterate to all nodes in the query.

```gdscript
onready var prop_cars := QGodot.get_query(
	"StaticBody",
	[
		"Wheels/Wheel0",
		"Wheels/Wheel1",
		"Wheels/Wheel2",
		"Wheels/Wheel3"
	]
)


func _process(delta):
	for binds in prop_cars.iterate():
		binds["self"].global_translation.z += 0.1
		binds["Wheels/Wheel0"].rotation.x += 0.1
		binds["Wheels/Wheel1"].rotation.x += 0.1
		binds["Wheels/Wheel2"].rotation.x += 0.1
		binds["Wheels/Wheel3"].rotation.x += 0.1
```

However, if this is only one function you use, consider using `QGodot.query()` to directly obtain array for iteration.

```gdscript
onready va prop_cars := QGodot.query( # just use '.query()' to obtain an array.
	"StaticBody",
	[
		"Wheels/Wheel0",
		"Wheels/Wheel1",
		"Wheels/Wheel2",
		"Wheels/Wheel3"
	]
)


func _process(delta):
	for binds in prop_cars: # No need for '.iterate()'.
		binds["self"].global_translation.z += 0.1
		binds["Wheels/Wheel0"].rotation.x += 0.1
		binds["Wheels/Wheel1"].rotation.x += 0.1
		binds["Wheels/Wheel2"].rotation.x += 0.1
		binds["Wheels/Wheel3"].rotation.x += 0.1
```

#### `half_iterate(): Array`
This will split query into half and iterate only one part of it, swap to another half next frame and the cycle continues on.

```gdscript
onready var prop_cars := QGodot.get_query(
	"StaticBody",
	[
		"Wheels/Wheel0",
		"Wheels/Wheel1",
		"Wheels/Wheel2",
		"Wheels/Wheel3"
	]
)


func _process(delta):
	for binds in prop_cars.half_iterate():
		binds["self"].global_translation.z += 0.1
		binds["Wheels/Wheel0"].rotation.x += 0.1
		binds["Wheels/Wheel1"].rotation.x += 0.1
		binds["Wheels/Wheel2"].rotation.x += 0.1
		binds["Wheels/Wheel3"].rotation.x += 0.1
```

#### `size(): int`
Get number of nodes in the query.
