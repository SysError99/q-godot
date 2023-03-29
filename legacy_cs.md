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

When starting the game, query isn't ready yet. If you try to query at this moment (especially on first game start), you will have an array of zero elements. In case you wanted to query for nodes in very early stages, you should always make sure that query is ready to be used. In this case, QGodot provides `QGodotSharp.Ready()` signal that you can `await` on:

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

*Note: on runtime, `Main Scene` (in project settings) will be automatically registered until the use of other functions outside `QGodotSharp.ChangeScene()` to change between scenes.*

```cs
QGodotSharp.ChangeScene("res://target_scene.tscn");
```

---

## Cleaning Up And Changing Scene
This is proper way to clean up everything before changing scene to ones that don't require querying:

```cs
QGodotSharp.FlushAndChangeScene("res://non_qgodot_related_scene.tscn");
```

---

## Registering Node As Scene Root
By default, current scene will be a node that will be scanned, but sometimes you wanted the addon to only scan through specified nodes. There are two ways to handle it.

First is to add the node into `registered_scene` group.

![image](https://user-images.githubusercontent.com/17522480/212744832-99470db1-b5cb-4895-849c-509ac744e41a.png)

*NOTE: For performance reasons, if you add nodes that include `registered_scene` by script, it will not be added into scene list. You must use `QGodotSharp.RegisterAsScene()` to manually register them, as explained below.*

Second, is by code:

```cs
QGodotSharp.RegisterAsScene(myTargetNode);
```

---

## One-shot Query Binding
Sometimes you don't really want to iterate all nodes in every given frame, such as, you wanted to do event-driven programming (using `Signal`), you can do one-shot binding instead:

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
If performance is a concern, and you don't really want to iterate all entities in single frame, you can also split query into half and iterate all of them in two frames. You can use `QGodotSharp.QueryHalf()` to get `System.Collections.Generic.IEnumerable<T>` that handles half query reference automatically:

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
