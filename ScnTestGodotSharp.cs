using Godot;
using SysError99;


public class ScnTestGodotSharp : Node2D
{
    private static readonly Vector2 Target = new Vector2(512, 300);

    private Label _label;

    public override void _Ready()
    {
        ulong seed = 0;
        GD.RandSeed(814995, out seed);
        _label = GetNode<Label>("CanvasLayer/Label");

        var currentScene = GetTree().CurrentScene;
        for (var x = 0; x < 10000; x++)
        {
            var clone = new KinematicBody2D();
            var sprite = new Sprite();
            clone.Name = "Icon" + x;
            sprite.Name = "Sprite";
            sprite.Texture = GD.Load<Texture>("res://icon.png");
            clone.Position = new Vector2(GD.Randi() % 1024, GD.Randi() % 1024);
            clone.AddChild(sprite);
            currentScene.AddChild(clone);
        }

        QGodotSharp.BindQuery<KinematicBody2D, Sprite>(this, nameof(_EntityEnteredScene), true);
    }

    public void _EntityEnteredScene(KinematicBody2D parent, Sprite sprite)
    {
        GD.Print(parent.Name + " entered scene!");
        sprite.Scale = Vector2.One * 4f;
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
}
