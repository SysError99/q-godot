# QGodot
Advanced yet simple node querying library for Godot. Resembles a lot with Entity Component System (ECS) architecture.

- #### [API Reference](https://github.com/SysError99/q-godot/blob/main/reference.md)

---

## This Project Is Still (mainly) On Godot 3.x!
However, I already made parts that are 4.0 compatible, simply uncomment lines with double number sign (`##`) and remove lines above it, and that should do it.

Also, this project still doesn't target 4.0 just yet, since my main workflow is still on 3.x and I couldn't move it towards 4.0 easily since I still need to ship my games mainly on web platform, which Godot 4.0 still isn't mature enough (it has significant bugs on macOS/iOS platforms, which isn't feasible).

However, feel free to contribute 4.0 elements and put proper double number sign comments on it!

---

## C# Deserves Better!
As I read through how C# interface for QGodot is developed, it become apparent that C# version would present more hassle than help. The code is quite unintuitive and cubersome to use, plus enormous size of source file and bad documentation. Ultimately I decided to drop entire aspect of C# version entirely for the upcoming version 0.2. However, if you are using 0.1 version with C#, documention can still be accessed [here](https://github.com/SysError99/q-godot/blob/main/legacy_cs.md).

---

## Disclaimer
This addon will NOT address any of performance benefits, unlike many of ECS libraries that claim to have. This project is made for purely programming aesthetics only. However, unlike other GDScript-based ECS libraries, this project offers ECS-like programming experience with very comparable performance against traditional OOP programming in GDScript.

---

## How This Add-on Works
In the world of programming, Entity Component System, or ECS, is another form of programming paradigm(?) that got rised an attention for quite awhile (however ECS by itself was actually used for decades, it just doesn't have any of names at the time). The way you think about ECS is a different approach compared to traditional object-oriented paradigm. Essentially, you *throw away* (almost) all concepts of trying to combine logic (function, method) with data (proprety) along with concept of 'messaging'. Instead, you make data and logic completely separated from each other, then try to manipulate each data without thinking how 'objects' communicate with each other. Now, you have 'entity', which is just a shell for containing multiple 'components' or data inside. Then, you have 'system' which is the logic of the software. Entities will be stored inside 'world' which resembles database of the software. You try to define entites their its compoments, then store them in world and use systems to manipulate/represent them.

Godot, by itself, IS NOT an ECS game engine, and will NEVER be. Although it has very intutive 'Node' system, which is a form of object composition interface that makes them being able to communicate, but the way that it gets programmed still is around object-oriented, which could lead to complications if not controlled properly. E.g., you write functions for all related objects/nodes so they can communicate with each other. When requirements keep increasing, you ended up with A LOT of functions that wrangled and become more difficult to make changes at a risk of destorying entire logic. In some of tasks, it's just not intuitive to code in object-oriented if you have certain different objects/nodes that you wanted to make changes on them. Also, in good project management in object-oriented software development, adding more scripts can help organising projects, but it can also lead to complications of source management at a same time, especially if those objects don't really need to run specific scripts all the time and need to be swap around constantly.

However, the most complicated thing in ECS is how to define concepts of 'world', 'entity', 'component', and the most important part is how to 'query' those stuffs out to be processed and put result back. As we all know that Godot isn't an ECS game engine, and basically every node is an object (or entity). Godot can certainly do something like ECS, but it become very cubersome to use the node sytem to query nodes as to simulate how querying works in ECS. It simply isn't intuitive enough to code in ECS way in Godot if we use its integrated functions in it. Not to mention, this way of code isn't efficient and tend to be slower than traditional object-oriented coding in Godot because of overhead in GDScript's field access operations.

This is where this add-on comes in, it adds intuitive way of how to code in Godot by applying ECS-like architecture to it. Instead of trying to add logic to the node itself, we separate game logic into 'system' nodes. Then we use these system nodes as our main ways to interact with nodes instead. However, since Godot's 'Node' system is very flexible by presenting itself in node tree, it become more challenging to implement ECS paradigm into the engine itself since usually ECS is only about entity that contains components, but Godot's 'Node' can be nested infinitely, which presests the challenge on how to efficiently query nodes without the need to write a lot of code to just trying to find them.

I decided to go with a route that presented in the way that is as close as ECS as possible. This is what I went with.

- `scene` is a world in ECS. QGodot treats root scene as entire world.
- `main_node` is an entity in ECS. This is node type that you use to store other sub nodes inside. `main_node`s can exist anywhere in the scene tree.
- `sub_node` is a component in ECS. This is node type that is used to behave as data or another representation of the main node. `sub_node`s exist inside the `main_node` at any of tree depth. QGodot will try its best to query the specified sub nodes that match the query criteria.

This way it opens up possibilities to use ECS in Godot without the need to reconstruct entire game engine, and doesn't need to strictly use ECS all the time if it doesn't need to be that way. Also, this add-on can be used on top of existing projects to do certain tasks, so you don't need to rework entire project just to try out or use ECS in your object-oriented projects.

---

## Quickstart
Import `q_godot.gd` into AutoLoad in your project as any of names you want, `QGodot` will be a default name.

![image](https://user-images.githubusercontent.com/17522480/212733830-72a3cc8e-e028-4299-9acc-cb9f8ffe83f2.png)

Then, setup nodes that will be controlled by our first system. In this case, we will have `KinematicBody2D` node that has an `Icon` node inside:

![image](https://user-images.githubusercontent.com/17522480/212737269-fe81e97d-011f-4bd9-b9c0-1bb5515d35b6.png)

Now we can have our first system that will control three nodes. First, create a script that binds to our game scene. In this case, we will keep it simple by attaching a new script to parent node of the scene:

![image](https://user-images.githubusercontent.com/17522480/212734669-fdf68bf6-7db4-440f-9306-254e4a719ffb.png)

Let's 'subscribe' to our first query!:

```gdscript
extends Node2D

# First argument of the function will be 'main class name' of parent node.
onready var query := QGodot.query("KinematicBody2D")
```

Now we can iterate through our subscribed query in `_process()` :

```gdscript
const TARGET = Vector2(512,300)

func _process(_delta: float) -> void:
	for binds in query:
		var entity := binds["self"] as KinematicBody2D
		var vel := entity.position.direction_to(TARGET)
		entity.move_and_slide(vel)
		entity.look_at(TARGET)
```

The rest of code should be something like this:

```gdscript
extends Node2D


const TARGET = Vector2(512,300)


onready var query := QGodot.query("KinematicBody2D")


func _process(_delta: float) -> void:
	for binds in query:
		var entity := binds["self"] as KinematicBody2D
		var vel := entity.position.direction_to(TARGET) * 10.0
		entity.move_and_slide(vel)
		entity.look_at(TARGET)
```

When you start running the game, voila!

![image](https://user-images.githubusercontent.com/17522480/212736180-a8f69a45-ba88-4159-87ef-dba16b5f130b.png)

Now, we wanted constantly scale icon size by making changes on the `Icon` 'sub' node. Let's make change on the query and add an extra argument that is used for querying sub nodes:

```gdscript
# Second argument will be array of node names that you wanted to match. In this case, we only have 'Icon'.
onready var query := QGodot.query("KinematicBody2D", ["Icon"])
```

Then, on the `_process()` loop, we can retrieve the sub node we added to the query (in this case, `Icon`):

```gdscript
func _process(_delta: float) -> void:
	for binds in query:
		var icon := binds["Icon"] as Sprite
		icon.scale = icon.scale * 1.01
```

The rest of code now should be something like this:

```gdscript
extends Node2D


const TARGET = Vector2(512,300)


onready var query := QGodot.query("KinematicBody2D", ["Icon"])


func _process(_delta: float) -> void:
	for binds in query:
		var entity := binds["self"] as KinematicBody2D
		var icon := binds["Icon"] as Sprite
		var vel := entity.position.direction_to(TARGET) * 10.0
		entity.move_and_slide(vel)
		entity.look_at(TARGET)
		icon.scale = icon.scale * 1.01
```

When we start the project again, the icon now scales indefinitely!

![image](https://user-images.githubusercontent.com/17522480/212738843-e2db606d-1c83-4f79-b335-f7a972cc3d5a.png)

---

## Querying Main Nodes with Custom Scripts
QGodot not only limit main node types to only be internal types (retrieve from `Object.get_class()`), but you can also use `Script` types (ones that get defined with `class_name`) to query nodes with custom types/scripts.

```gdscript
class Enemy extends KinematicBody2D:
	...


# Query enemies with superweapon.
onready var enemies := QGodot.query(Enemy, [ "Superweapon" ])
```

QGodot also does query custom nodes on queries that use default node names, This is for further flexibility:

```gdscript

class EnemyBoss extends KinematicBody:
	...


# Enemy bosses
onready var enemy_bosses := QGodot.query(EnemyBoss, [ "Loot" ])


# Any of monsters that don't need any of specific custom nodes, which means that 'EnemyBoss' nodes will also be included.
onready var npcs := QGodot.query("KinematicBody", [ "Loot" ])
```

*NOTE: QGodot DOES NOT support dynamic script assigning (with `Object.set_script()`) as it will cause unexpected behaviour in querying mechanism.*

---

## Searching For Nodes In Query With Main Node Names
You can also search for particular nodes and sub nodes in the query by using main node name (similar to how you do it with `get_node()` or `get_tree().get_nodes_in_group()`). This will be very useful in online games that you need to constantly stream data from server to client. However, this sacrifices the RPC performance benefits in exchange of ease of use (for ones who like manual data control flow than trying to comprehend how RPC paradigm works). This is done by using a dictionary `by_name` to search for nodes in query.

This example demonstrates how to find nodes with names using `by_name` of query.

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

*NOTE: If there are more than one main node with same name, the mechanism will be MESSED UP. Make sure that all nodes have unique names.*

---

## Flushing Before Changing Between Scenes
This is proper way to clean up everything before changing scene.

```gdscript
QGodot.flush() # Clean up everything in QGodot.
get_tree().change_scene("res://next_scene.tscn")
```

---

## Binding Events When Main Nodes Enter Scene Tree
Sometimes you don't really want to iterate all nodes in every given frame, such as, you just wanted to detect if new nodes fitting query criteria have entered the scene tree, you can do one-shot binding instead:

```gdscript
QGodot.bind_query(
	"KinematicBody2D",
	["Icon"]
	self, # Target object to bind (in this case, this script)
	"entity_entered" # Function name to bind
)


# In this case, naming is no longer a concern. However, it still needs to be in proper order, and first argument is still a parent node.
func entity_entered(parent: KinematicBody2D, icon: Sprite) -> void:
	var tween := $Tween as Tween
	icon.scale = Vector2.ONE * 4
	tween.interpolate_property(
		parent, "position",
		parent.position, Vector2(512, 300),
		60
	)
	tween.start()
```

---

## Half-iterating Nodes In Single Frame (For Performance Boost)
If performance is a concern, and you don't really want to iterate all main nodes in single frame, you can also split query into half and iterate all of them in two frames. You can use `get_query()` to get `Query` object, then use `Query.half_iterate()` to retrieve half of array for each frame.

```gdscript
onready var query := QGodot.get_query("KinematicBody2D", ["Icon"])


func _process(delta: float) -> void:
	for binds in query.half_iterate():
		var entity := binds["self"] as KinematicBody2D
		var icon := binds["Icon"] as Sprite
		var vel := entity.position.direction_to(TARGET) * 10.0
		icon.scale = icon.scale * 1.01
		entity.move_and_slide(vel)
		entity.look_at(TARGET)
```

*Note: due to how it works, this should NOT be used with main nodes that has critical physics calculation elements since it may cause unexpected results.*

*Note II: in low frame (below 60), it will cause horrible jittery artifacts when there's a movement of main nodes.*

*Note III: you should always multiply value by 2 in movement vectors to compensate frame skipping.*

---

## Adding/Removing Sub Nodes And Groups In Main Nodes (Right Way)
You should always try to add new sub nodes when the main node is not inside scene tree. Or QGodot will not be able recognise new sub nodes and perform proper query bindings.

Assuming the main node (entity in ECS) is `enemy`, and sub node (component in ECS) is `superpower`.

This is RIGHT way to add new sub nodes:
```gdscript
var enemy := preload("res://enemies/enemy.tscn").instance()
var superpower := preload("res://weapons/superweapon.tscn").instance()
enemy.add_child(superpower)
get_tree().current_scene.add_child(enemy)
```

This is WRONG way to add new sub nodes, QGodot will NOT be able to detect new nodes at all:
```gdscript
var enemy := preload("res://enemies/enemy.tscn").instance()
var superpower := preload("res://weapons/superweapon.tscn").instance()
get_tree().current_scene.add_child(enemy)
enemy.add_child(superpower) # Adding sub nodes after adding main node to scene tree will result in QGodot not being able to detect new sub nodes!
```

However, if you wanted to add or remove sub nodes while **the main node is already in scene tree**, you can use `refresh_query_on_node()` to perform querying on the particular node again.

```gdscript
enemy.add_to_group("dying")
enemy.get_node("Superpower").queue_free()
QGodot.refresh_query_on_node(enemy)
```

---

## Querying Nodes That Are In Sub Nodes
If you also wanted to query nodes that are in other nodes, you can also use node path to query them:

```gdscript
onready var bodies := QGodot.query("KinematicBody", [ "Status", "Viewport/HpBar" ])


func _process(delta: float) -> void:
	for binds in bodies:
		var body := binds["self"] as KinematicBody
		var status := binds["Status"] as Status
		var hp_bar := binds["Viewport/HpBar"] as Control
		hp_bar.rect_size.x = status.hp_percent
```

---

## Using Godot Groups In Query
You can also add 'groups' into the query if you wanted to have better node filtering. Just add them into array of second argument after node names.

Example, querying `KinematicBody2D` with `Sprite` node named 'Icon', in the group 'enemy':

```gdscript
onready var query := QGodot.query("KinematicBody2D", ["Icon", "enemy"])
```

Adding and removing groups while the main node is on scene tree is exactly the same on how you do it with sub nodes. Just run `refresh_query_on_node()` right after changes have been applied:

```gdscript
enemy.add_child(load("res://weapons/superweapon.tscn").instance())
enemy.add_to_group("high_atk")
QGodot.refresh_query_on_node(enemy)
```

---

## Excluding Nodes And Groups In Query
In order if you wanted to exclude certain sub nodes and groups from query, simply add `-` before node path or group.

```gdscript
# Query that includes player.
onready var players := QGodot.query("KinematicBody", ["player"])


# Query that excludes player.
onready var npcs := QGodot.query("KinematicBody", ["-player"])


# Query that includes and excludes certain sub nodes.
onready var wild_horses := QGodot.query("KinematicBody", ["HorseSound", "-Inventory"])
```

---

## Binding Query With Instantiable References
Sometimes you wanted to iterate through nodes but using instantiable classes. This will slightly helps on speed since it doesn't require constant use of bindings to get sub nodes. Which means, `QGodot.bind_query()` will help us in this case. However, this will increase memory usage, and is slightly more tricky to use.

```gdscript
extends Node
var count := 0


func _ready() -> void:
	QGodot.bind_queqy(
		"KinematicBody2D",
		["Icon"],
		Movement, # Class name reference, or loaded 'GDScript'.
		self # Use this instance as shared object for this query.
	)


class Movement extends Node:
	const TARGET = Vector2(512, 300)
	
	# Reserved fields
	var shared: Node

	# User-defined fields
	var parent: KinematicBody2D
	var icon: Sprite

	func _init(parent, icon) -> void:
		self.parent = parent
		self.icon = icon

	func _ready() -> void:
		shared.count += 1
	
	func _process(_delta: float) -> void:
		var vel := parent.position.direction_to(TARGET) * 10.0
 		parent.move_and_slide(vel)
 		parent.look_at(TARGET)
 		sprite.scale *= 1.001
```

---

## Creating Global Signals
In case you wanted to add event-driven programming but handling signals on many of nodes sounds like a hassle than help. This add-on instead provides an easy-to-use global signal feature that is safe to use and very loosely tied. You longer need to worry about signal existence since it's handled automatically.

For example, system node `A` loosely connnects to the `unit_killed` signal. Signal technially doesn't exist yet, but it awaits until the signal is created:
```gdscript
func _enter_tree() -> void:
	QGodot.signal_connect("unit_killed", self, "_unit_killed")


func _unit_killed(killer: KinematicBody2D, target: KinematicBody2D) -> void:
	print("%s killed %s" % [killer.name, target.name])
```

Now, other system nodes can call function `signal_emit()` to emit signals. Now all awaiting system nodes will receive this signal:
```gdscript
QGodot.signal_emit("unit_killed", [unit, target])
```

*CAUTION: DO NOT USE SAME SIGNAL NAME BUT WITH DIFFERENT PARAMETER LENGTH, OR IT WILL RESULT IN UNSUCCESSFUL SIGNAL CREATION AND EMISSION. `flush()` WILL NOT HELP.*

---

## Coroutine With Global Signals
For the clean, procedural code, you can also `yield()` global signals on demand withot the need to manually create state manager objects. Simply use `to_signal()` to generate an awaiter, and `yield` for `completed` signal.

```gdscript
yield(QGodot.to_signal("level_finished"), "completed")
```

On the emitter, you can use `signal_emit()` as normal. However, this time it ONLY supports ONE PARAMETER. If you try to push it more than one, it will FAIL to emit and show an error on the debuging console.

```gdscript
QGodot.signal_emit("level_finished", [ 1 ]) #✔️ supported
QGodot.signal_emit("level_finished", [ 1, "good score" ]) #❌ NOT supported, will cause an error
```

---

## Additional Features
This won't fall to any of categories in how QGodot behaves, but it's good little additions.

1. `get_first_node(group_name: String): Node` get first node that is in the specified group.
2. `System` a class that helps making code shorter by omitting `QGodot` singleton calls altogether, making code far cleaner to read. Simply extend any system classes with `QGodot.System`. Now all functions from `QGodot` should be available, except for `is_second_frame` which has changed to a function `is_second_frame()` instead.
```gdscript
extends QGodot.System

# 'QGodot.query' gets shortened to just 'query'
onready var owned_horses := query("KinematicBody2D", ["Inventory", "horse"]) 


func _ready() -> void:
	# 'QGodot.to_signal' gets shortened to just 'to_signal'
	yield(to_signal("game_loaded"), "completed")
	print("Game is fully loaded!")


func _process(_delta: float) -> void:
	# Only API reference that has been changed, you must call it as function instead
	# 'QGodot.is_second_frame' -> 'is_second_frame()'
	if is_second_frame():
		print("This is second frame.")
```

---
