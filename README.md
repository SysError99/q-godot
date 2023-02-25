# QGodot
Advanced yet simple node querying library for Godot. Resembles a lot with Entity Component System (ECS) architecture.

---

## Disclaimer
This addon will NOT address any of performance benefits, unlike many of ECS libraries that claim to have. This project is made for purely programming aesthetics only. However, unlike other GDScript-based ECS libraries, this project offers ECS-like programming experience with very comparable performance against traditional OOP programming in GDScript.

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
	for entity in query:
	var vel := (entity.position.direction_to(TARGET) * 10.0) as Vector2
	entity.move_and_slide(vel)
	entity.look_at(TARGET)
```

The rest of code should be something like this:

```gdscript
extends Node2D


const TARGET = Vector2(512,300)


onready var query := QGodot.query("KinematicBody2D")


func _process(_delta: float) -> void:
	for entity in query:
	var vel := (entity.position.direction_to(TARGET) * 10.0) as Vector2
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

Then, on the `_process()` loop, we can retrieve the sub node we added to the query (in this case, `Icon`) by using `get_meta()` from the main node:

```gdscript
func _process(_delta: float) -> void:
	for entity in query:
		# When querying by 'get_meta()', you must add dollar sign ('$') in front of node name.
		var icon := entity.get_meta("$Icon") as Sprite
		icon.scale = icon.scale * 1.01
```

The rest of code now should be something like this:

```gdscript
extends Node2D


const TARGET = Vector2(512,300)


onready var query := QGodot.query("KinematicBody2D", ["Icon"])


func _process(_delta: float) -> void:
	for entity in query:
	var vel := (entity.position.direction_to(TARGET) * 10.0) as Vector2
		var icon := entity.get_meta("$Icon") as Sprite
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
	for node in query:
		var icon := node.get_meta("$Icon") as Sprite
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

## Changing Scene
This addon heavily relies on proper singal bindings and node setups, thus require its own function to change scenes.

```gdscript
QGodot.change_scene("res://target_scene.tscn")
```

```cs
QGodotSharp.ChangeScene("res://target_scene.tscn");
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

## Making Scenes Persistent
If you don't want particular scene queries to get wiped out by the function `change_scene()`, you can add group `persistent_scene` for those scenes.

![image](https://user-images.githubusercontent.com/17522480/214317941-9ff54e07-30f4-47ba-bd80-7fdb1a6bbcde.png)

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

## Current Scene Query Binding
Sometimes, you don't really want all systems in the game to run all the time in all scenes. You can instead bind query using `bind_query_to_current_scene()`:

```gdscript
QGodot.bind_query_to_current_scene(
	"KinematicBody2D",
	["Icon"],
	self,
	"entity_entered"
)
```

On C#, after second parameter of the function, add `true` after it:

```cs
QGodotSharp.BindQuery<KinematicBody2D, Sprite>(this, nameof(_EntityEnteredScene), true);
```

---

## Binding Query That Will Only Be Iterated Half Entities Each Frame
If performance is a concern, and you don't really want to iterate all entities in single frame, you can also split query into half and iterate all of them in two frames. You can use `query_half()` to get `HalfQueryReference`, then use `HalfQueryReference.iterate()` to retrieve half of array for each frame.

```gdscript
onready var query := QGodot.query_half("KinematicBody2D", ["Icon"])


func _process(delta: float) -> void:
	for entity in query.iterate():
		var vel := (entity.position.direction_to(TARGET) * 10.0) as Vector2
		var icon := entity.get_meta("$Icon") as Sprite
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

## Using Godot Groups In Query (GDScript Only)
You can also add 'groups' into the query if you wanted to have better node filtering. Just add them into array of second argument after node names.

Example, querying `KinematicBody2D` with `Sprite` node named 'Icon', in the group 'enemy':

```gdscript
onready var query := QGodot.query("KinematicBody2D", ["Icon", "enemy"])
```

---

## Adding Nodes To Groups (GDScript Only)
For performacne reasons, QGOdot will NOT do automatic query binding when new groups have been added to nodes (there is no signal options addressing such issue also) while the node has already joined the scene tree. To address this issue, QGodot provides `add_node_to_group()` and `remove_node_from_group()` to perform automatic query binding after adding groups to the node.

```gdscript
QGodot.add_node_to_group(node_name, "group_name")
```
```gdscript
QGodot.remove_node_from_group(node_name, "group_name")
```

---

## Querying Nodes That Are In Sub Nodes (GDScript Only)
If you also wanted to query nodes that are in other nodes, you can also use node path to query them:

```gdscript
onready var bodies := QGodot.query("KinematicBody", [ "Status", "Viewport/HpBar" ])
```

When querying nodes with `get_meta()` it goes exactly the same way as `get_node()` but with extra `$` symbol:
```gdscript
func _process(delta: float) -> void:
	for body in bodies:
		var status := body.get_meta("$Status") as Status
		var hp_bar := body.get_meta("$Viewport/HpBar") as Control
		hp_bar.rect_size.x = status.hp_percent
```

---

## Binding Query With Instantiable References (GDScript Only)
Sometimes you wanted to iterate through nodes but using instantiable classes. This will slightly helps on speed since it doesn't require constant use of `get_meta()` to get sub nodes. Which means, `QGodot.bind_query()` will help us in this case. However, this will increase memory usage, and is slightly more tricky to use.

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
		var vel := (parent.position.direction_to(TARGET) * 10.0) as Vector2
 		parent.move_and_slide(vel)
 		parent.look_at(TARGET)
 		sprite.scale *= 1.001
```

---
