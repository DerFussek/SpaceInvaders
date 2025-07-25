using System;
using Godot;

[GlobalClass]
public partial class Bullet : Area2D
{
	[Export]
	private float speedFactor = 150.0f;
	Vector2 dir;	private Sprite2D sprite;

	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		dir = new Godot.Vector2(0, -1) * this.speedFactor;
		Position += dir * (float)delta;

		if (checkForDeath()) QueueFree();
	}

	private Boolean checkForDeath()
	{
		return Position.Y <= 0 - 32;
	}

	public void suicide()
	{
		this.QueueFree();
	}
}
