using System;
using Godot;


public partial class Player : CharacterBody2D
{

	[Export(PropertyHint.Link)]
	private Vector2 speed = new Vector2(200, 0);

	private PackedScene bulletScene;

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{

		MovementInput();
		MoveAndSlide();
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
	private void MovementInput()
	{
		float dir = Input.GetAxis("left", "right");
		Velocity = speed * dir;
	}
}
