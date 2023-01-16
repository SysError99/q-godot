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


Then, we will start writing our first iterator class that is instantiable.:
```gdscript
extends Node2D


class MovementIterator extends Node:
    const TARGET = Vector2(512, 300) # Target position that node needs to move into.
    var parent: KinematicBody2D # Parent node binder, must be properly casted to parent node type.
    func _process(delta):
        # Simple movement script.
        var vel := parent.position.direction_to(TARGET) * 10.0
        parent.move_and_slide(vel)
        parent.look_at(TARGET)
```

Now, on `_ready()` block, we can bind our iterator:

```gdscript
func _ready():
    QGodot.bind_query(
        # Array of all nodes you want to query. First element must be 'main class name' of parent node.
        # In this case 'KinematicBody2D' (it doesn't care about node name)
        ["KinematicBody2D"], 
        MovementIterator
    )
```

In the end, script should be something like this:

![image](https://user-images.githubusercontent.com/17522480/212736011-6d8a6cd5-9439-4d2d-bebf-bba0c098b2ee.png)

When you start running the script, voila!

![image](https://user-images.githubusercontent.com/17522480/212736180-a8f69a45-ba88-4159-87ef-dba16b5f130b.png)

Now, we wanted to change `Icon` size by code. On `_ready()` function, we will add node name into the array that is used for querying:

```gdscript
    QGodot.bind_query(
        # Again, first element will always be 'main class name' of parent node.
        # Other sub nodes (components) will use node names. In this case 'Icon'.
        ["KinematicBody2D", "Icon"],
        MovementIterator
    )
```

On `MovementIterator`, we will add binder and also icon scaling script:

```gdscript
    var icon: Sprite # Binder variable, must be converted to 'snake_case'.
    # For example, if a node name is 'PlayerStatus', it will be 'player_status'.
    # If it's 'Node2D', then it will be 'node_2d'.
    func _ready():
        # Simple scaling script
        icon.scale = Vector2.ONE * 4
```

The rest of the script should be something like this:

![image](https://user-images.githubusercontent.com/17522480/212739262-6c690840-22bc-4666-bd82-410c483606de.png)

When we start the project again, the icon is now scaled!

![image](https://user-images.githubusercontent.com/17522480/212738843-e2db606d-1c83-4f79-b335-f7a972cc3d5a.png)

---

## Quickstart (C#)
Importing is similar to GDScript variant, but instead it will be `QGodotSharp.cs` for script, and `QGodotSharp` for class.

Unlike GDScript variant, C# version doesn't need any of binder class, and instead just iterate list of classes directly:

```cs
public override void _Ready()
{
    await ToSignal(GetTree(), "idle_frame"); // Must wait at least one frame before query can occur
    foreach (var (parent, sprite) in QGodotSharp.Query<KinematicBody2D, Sprite>())
    {
        sprite.Scale = Vector2.One * 4f;
    }
}
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

Second, is by code:

```gdscript
QGodot.register_as_scene(my_target_node)
```

```cs
QGodotSharp.RegisterAsScene(myTargetNode);
```

---

## Iteration (GDScript)
Sometimes it's necessary to directly iterate through query. This can be addressed by using `query()` function. However, this function is very constly in terms of performance, and has limitations, such as, it has no automatic bindings, and requires parent node to be fully set up.

```gdscript
yield(get_tree(), "idle_frame") # If the script loads for first time, you may need to wait at least one frame.
for node in QGodot.query(["KinematicBody2D", "Icon"]):
    var parent: KinematicBody2D = node
    var icon := parent.get_node("Icon") as Sprite
```

---

## One-shot Query Binding (GDScript Only)
Sometimes you don't really want to iterate all nodes in every given frame, such as, you wanted to do event-driven programming (using `Signal`), you can do one-shot binding instead:

```gdscript
QGodot.bind_query(
    ["KinematicBody2D", "Icon"]
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

## Current Scene Query Binding (GDScript Only)
Sometimes, you don't really want all systems in the game to run all the time in all scenes. You can instaed bind query using `bind_query_to_current_scene()`:

```gdscript
QGodot.bind_query_to_current_scene(
    ["KinematicBody2D", "Icon"],
    MovementIterator,
)
```
