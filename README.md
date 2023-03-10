# QGodot
Advanced yet simple node querying library for Godot. Resembles a lot with Entity Component System (ECS) architecture.

---

## This Project Is Still (mainly) On Godot 3.x!
However, I already made parts that are 4.0 compatible, simply uncomment lines with double number sign (`##`) and remove lines below it, and that should do it.

Also, this project still doesn't target 4.0 just yet, since my main workflow is still on 3.x and I couldn't move it towards 4.0 easily since I still need to ship my games mainly on web platform, which Godot 4.0 still isn't mature enough (it has significant bugs on macOS/iOS platforms, which isn't feasible).

However, feel free to contribute 4.0 elements and put proper double number sign comments on it!

---

## Disclaimer
This addon will NOT address any of performance benefits, unlike many of ECS libraries that claim to have. This project is made for purely programming aesthetics only. However, unlike other GDScript-based ECS libraries, this project offers ECS-like programming experience with very comparable performance against traditional OOP programming in GDScript.

---

## How This Add-on Works
In the world of Entity Component System, or ECS, is another form of programming paradigm(?) that got rised an attention for quite awhile (however ECS by itself was actually used for decades, it just doesn't have any of names at the time). The way you think about ECS is a different approach compared to traditional object-oriented paradigm. Essentially, you *throw away* (almost) all concepts of trying to combine logic (function, method) with data (proprety) along with concept of 'messaging'. Instead, you make data and logic completely separated from each other, then try to manipulate each data without thinking how 'objects' communicate with each other. Instead, you have 'entity', which is just a shell for containing 'components' or data. Then, you have 'system' which is the logic of the software. Entities will be stored inside 'world' which resembles database of the software. You try to define entites their its compoments, then store them in world and use systems to manipulate/represent them.

Godot, by itself, IS NOT an ECS game engine, and will NEVER be. Although it has very intutive 'Node' system, which is a form of object composition interface that makes them being able to communicate, but the way that it gets programmed still is around object-oriented, which could lead to complications if not controlled properly. E.g., you write functions for all related objects/nodes so they can communicate with each other, when it become more and more of requirements, you ended up with A LOT of functions that wrangled and become more difficult to make changes without destorying entire logic. In some of tasks, it's just not intuitive to code in object-oriented if you have certain different objects/nodes that you wanted to make changes on them, but adding more scripts to objects can also lead to complications of source management, especially if those objects don't really need to run specific scripts all the time.

However, the most complicated thing in ECS is how to define concepts of 'world', 'entity', 'component', and the most important part is how to 'query' those stuffs out. As we all know that Godot isn't an ECS game engine, and basically every node is an object (or entity). Godot can certainly do something like ECS, but it become very cubersome to use the node sytem to query nodes as to simulate how querying works in ECS. It simply isn't intuitive enough to code in ECS way in Godot if we use its integrated functions in it. Not to mention, this way of code isn't efficient and tend to be slower than traditional object-oriented coding in Godot.

This is where this add-on comes in, it adds intuitive way of how to code in Godot by applying ECS-like architecture to it. Instead of trying to add logic to the node itself, we separate them into 'system' nodes. Then we use these system nodes as our main ways to interact with nodes. However, since Godot's 'Node' system is very flexible by presenting itself in node tree, it become more challenging to implement ECS paradigm into the engine itself. I decided to go with a route that presented in the way that is as close as ECS as possible. This is what I went with.

- `scene` is a world in ECS. You can register as many scene nodes as you want to make querying happen.
- `main_node` is an entity in ECS. This is node type that you use to store other sub nodes inside.
- `sub_node` is a component in ECS. This is node type that is used to behave as data or another representation of the main node. Sub nodes can be nested in each other, which this add-on will also take advantage of them.

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

*NOTE: You should always make a query with `onready`, or before `query_ready` signal. Making a query after `query_ready` signal may give empty query results.*

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

## Quickstart (C#)
You need to import `QGodotSharp.cs` along with `q_godot.gd` before using it. All C# variant functions are inside `SysError99.QGodotSharp`.

Unlike GDScript, C# version utilises C#'s `Tuple` to query nodes. and first element will always be class reference of parent node:

```cs
using Godot;
using SysError99;
using System.Collections.Generic;

public class MySystem : Node
{
	private static readonly Vector2 Target = new Vector2(512f, 300f);

	public override void _Process(float delta)
	{
		foreach (var (parent, sprite) in QGodotSharp.Query<KinematicBody2D, Sprite>())
		{
			var vel = parent.Position.DirectionTo(Target) * 10;
			parent.MoveAndSlide(vel);
			parent.LookAt(Target);
		}
		_label.Text = "FPS: " + Engine.GetFramesPerSecond();
	}
}

```

You can also use `System.Collections.Generic.IEnumerable<T>` to create a query before using it instead.

```cs
using Godot;
using SysError99;
using System.Collections.Generic;

public class MySystem : Node
{
	private static readonly Vector2 Target = new Vector2(512f, 300f);
	private IEnumerable<(KinematicBody2D, Sprite)> _query = QGodotSharp.Query<KinematicBody2D, Sprite>();

	public override void _Process(float delta)
	{
		foreach (var (parent, sprite) in _query)
		{
			var vel = parent.Position.DirectionTo(Target) * 10;
			parent.MoveAndSlide(vel);
			parent.LookAt(Target);
		}
	}
}

```

---

## Querying On Game Start
When starting the game, query isn't ready yet. If you try to query at this moment (especially on first game start), you will have an array of zero elements. In case you wanted to query for nodes in very early stages, you should always make sure that query is ready to be used. In this case, QGodot provides `query_ready` signal that you can `yield()`:

```gdscript
onready var query := QGodot.query("KinematicBody2D", ["Icon"])


func _ready() -> void:
	yield(QGodot, "query_ready")
	# QGodot is now ready to be used.
	for binds in query:
		var icon := binds["Icon"] as Sprite
		icon.scale = Vector2.ONE * 4
```

On C# version is very similar, however, `QGodotSharp` provides `Ready()` function to be `await`ed on:

```cs
public override async void _Ready()
{
	await QGodotSharp.Ready();
	foreach (var (parent, sprite) in QGodotSharp.Query<KinematicBody2D, Sprite>())
	{
		sprite.Scale = Vector2.One * 4f;
	}
}
```

---

## Changing Scene (To QGodot Scenes)
This addon heavily relies on proper singal bindings and node setups, thus require its own function to change scenes (into ones that need QGodot to function).

*Note: on runtime, `Main Scene` (in project settings) will be automatically registered until the use of other functions outside `QGodot.change_scene()` to change between scenes.*

```gdscript
QGodot.change_scene("res://target_scene.tscn")
```

```cs
QGodotSharp.ChangeScene("res://target_scene.tscn");
```

---

## Cleaning Up And Changing Scene
This is proper way to clean up everything before changing scene to ones that don't require querying:

```gdscript
QGodot.flush_and_change_scene("res://non_qgodot_related_scene.tscn")
```

```cs
QGodotSharp.FlushAndChangeScene("res://non_qgodot_related_scene.tscn");
```

---

## Registering Node As Scene Root
By default, current scene will be a node that will be scanned, but sometimes you wanted the addon to only scan through specified nodes. There are two ways to handle it.

First is to add the node into `registered_scene` group.

![image](https://user-images.githubusercontent.com/17522480/212744832-99470db1-b5cb-4895-849c-509ac744e41a.png)

*NOTE: For performance reasons, if you add nodes that include `registered_scene` by script, it will not be added into scene list. You must use `register_scene()` to manually register them, as explained below.*

Second, is by code:

```gdscript
QGodot.register_as_scene(my_target_node)
```

```cs
QGodotSharp.RegisterAsScene(myTargetNode);
```

---

## One-shot Query Binding
Sometimes you don't really want to iterate all nodes in every given frame, such as, you wanted to do event-driven programming (using `Signal`), you can do one-shot binding instead:

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

On C# version is quite similar, however, array of node names will instead be replaced with C# `Tuple`s:

```cs
	//
	QGodotSharp.BindQuery<KinematicBody2D, Sprite>(this, nameof(_EntityEnteredScene));
	//

public void _EntityEnteredScene(KinematicBody2D parent, Sprite sprite)
{
	GD.Print(parent.Name + " entered scene!");
	sprite.Scale = Vector2.One * 4f;
}

```

---

## Binding Query That Will Only Be Iterated Half Entities Each Frame
If performance is a concern, and you don't really want to iterate all entities in single frame, you can also split query into half and iterate all of them in two frames. You can use `query_half()` to get `HalfQueryReference`, then use `HalfQueryReference.iterate()` to retrieve half of array for each frame.

```gdscript
onready var query := QGodot.query_half("KinematicBody2D", ["Icon"])


func _process(delta: float) -> void:
	for binds in query.iterate():
		var entity := binds["self"] as KinematicBody2D
		var icon := binds["Icon"] as Sprite
		var vel := entity.position.direction_to(TARGET) * 10.0
		icon.scale = icon.scale * 1.01
		entity.move_and_slide(vel)
		entity.look_at(TARGET)
```

On C# version is quite similar. However, you don't need to use `HalfQueryReference.iterate()` since it's handled automatically.

```cs
private static readonly Vector2 Target = new Vector2(512f, 300f);
private IEnumerable<KinematicBody2D, Sprite> _query = QGodotSharp.QueryHalf<KinematicBody2D, Sprite>();

public override void _Process(float delta)
{
	foreach (var (parent, sprite) in _query)
	{
		var vel = parent.Position.DirectionTo(Target) * 10;
		parent.MoveAndSlide(vel);
		parent.LookAt(Target);
	}
}
```

*Note: due to how it works, this should NOT be used with entities that has critical physics calculation elements since it may cause unexpected results.*

*Note II: in low frame (below 60), it will cause horrible jittery artifacts when there's a movement of entities.*

*Note III: you should always multiply value by 2 in movement vectors to compensate frame skipping.*

---

## Adding New Sub Nodes To Main Node (Right Way)
You should always try to add new sub nodes when the main node is not inside scene tree. Or QGodot will not be able recognise new sub nodes and perform proper query bindings.

Assuming the node that will get scanned (world in ECS) is `registered_scene` node, main node (entity in ECS) is `enemy`, and sub node (component in ECS) is `superpower`.

This is RIGHT way to add new sub nodes:
```gdscript
var enemy := preload("res://enemies/enemy.tscn").instance()
var superpower := preload("res://weapons/superweapon.tscn").instance()
enemy.add_child(superpower)
registered_scene.add_child(enemy)
```

This is another way to add new sub nodes, albeit will be slower:
```gdscript
var enemy := preload("res://enemies/enemy.tscn").instance()
var superpower := preload("res://weapons/superweapon.tscn").instance()
registered_scene.add_child(enemy)
enemy.call_deferred("add_child", superpower)
```

This is WRONG way to add new sub nodes, QGodot will NOT be able to detect new nodes at all:
```gdscript
var enemy := preload("res://enemies/enemy.tscn").instance()
var superpower := preload("res://weapons/superweapon.tscn").instance()
registered_scene.add_child(enemy)
enemy.add_child(superpower) # Adding sub nodes after adding main node to scene tree will result in QGodot not being able to detect new sub nodes!
```

---

## Querying Nodes That Are In Sub Nodes (GDScript Only)
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

## Using Godot Groups In Query (GDScript Only)
You can also add 'groups' into the query if you wanted to have better node filtering. Just add them into array of second argument after node names.

Example, querying `KinematicBody2D` with `Sprite` node named 'Icon', in the group 'enemy':

```gdscript
onready var query := QGodot.query("KinematicBody2D", ["Icon", "enemy"])
```

---

## Adding Nodes To Groups When The Node Is On The Scene Tree (GDScript Only)
*You should add nodes to groups when the node isn't inside scene tree whenever possible.*

For performacne reasons, QGodot will NOT trigger query binding when new groups have been added to nodes after such node has joined scene tree. There is no signal options addressing such issue also. To address this issue, QGodot provides `add_node_to_group()` and `remove_node_from_group()` to perform automatic query binding after adding groups to the node.

```gdscript
QGodot.add_node_to_group(node_name, "group_name")
```
```gdscript
QGodot.remove_node_from_group(node_name, "group_name")
```

---

## Binding Query With Instantiable References (GDScript Only)
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
