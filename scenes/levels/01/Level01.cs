using Godot;
using System;

public partial class Level01 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private Button test;
	private PackedScene bulletScene;

	public override void _Ready()
	{
		test = GetNode<Button>("CanvasLayer/background/Button");
		test.Pressed += onPress;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}


	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("shoot"))
		{
			bulletScene = GD.Load<PackedScene>("res://scenes/bullet/basic_bullet.tscn");
                        Area2D item = bulletScene.Instantiate<Area2D>();
                        AddChild(item);
                        item.GlobalPosition = GlobalPosition;
		}
	}

	private void onPress()
	{
		PackedScene testScene = GD.Load<PackedScene>("res://scenes/bullet/basic_bullet.tscn");
		Area2D item = testScene.Instantiate<Area2D>();
		AddChild(item);
	}
}
