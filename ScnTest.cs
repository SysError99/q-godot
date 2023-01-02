using Godot;
using Groups = SysError99.GodotSharpGroups;

public class ScnTest : Node2D
{
    public override async void _Ready()
    {
        while (true)
        {   
            foreach (var (parent, node, node2d) in Groups.Query<Node, Node, Node2D>("test_primary_group"))
            {
                GD.Print(parent.Name + ": " + node.Name + ", " + node2d.Name);
            }

            GD.Print("---");
            await ToSignal(GetTree().CreateTimer(1.0f), "timeout");
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_accept"))
        {
            var currentScene = GetTree().CurrentScene;
            var newNode = currentScene.GetNode("Node8").Duplicate();
            newNode.Name = "CreatedNode";
            currentScene.AddChild(newNode);
        }
        if (@event.IsActionPressed("ui_end"))
        {
            GetTree().CurrentScene.GetNode("Node8/Two").QueueFree();
        }
        if (@event.IsActionPressed("ui_home"))
        {
            GetTree().CurrentScene.GetNode("Node8").AddChild(new Node2D());
        }
    }
}
