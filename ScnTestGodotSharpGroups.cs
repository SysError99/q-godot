using Godot;
using SysError99;


public class ScnTestGodotSharpGroups : Node2D
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
    }

    public override void _Process(float delta)
    {
        foreach (var (parent, sprite) in GodotSharpGroups.Query<KinematicBody2D, Sprite>())
        {
            var vel = parent.Position.DirectionTo(Target) * 10;
            parent.MoveAndSlide(vel);
            parent.LookAt(Target);
        }
        _label.Text = "FPS: " + Engine.GetFramesPerSecond();
    }
}
