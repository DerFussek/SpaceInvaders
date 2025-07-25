using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export(PropertyHint.Link)]
	private Vector2 speed = new(200, 0);
	private Vector2 size;

    public override void _Ready()
	{
		this.size = GetViewport().GetVisibleRect().Size;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		handleInput();
		MoveAndSlide();
		checkForWall();
	}

	private void checkForWall()
	{
		if (GlobalPosition.X <= 32) GlobalPosition = new Vector2(32, GlobalPosition.Y);
		if (GlobalPosition.X >= this.size.X - 32) GlobalPosition = new Vector2(size.X - 32, GlobalPosition.Y);
	}

	private void handleInput()
	{
		float dir = Input.GetAxis("left", "right");
		Velocity = speed * dir;

		if (Input.IsActionJustPressed("shoot"))
		{
			createBullet();
		}
	}

	private void createBullet()
	{
		PackedScene bulletScene = GD.Load<PackedScene>("res://scenes/bullet/bullet.tscn");
		Area2D bullet = bulletScene.Instantiate<Area2D>();
		AddSibling(bullet);
		bullet.GlobalPosition = GlobalPosition;	
	}
}
