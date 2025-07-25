using Godot;
using System;

public partial class Enemie : CharacterBody2D
{

	[Export]
	private float speedMultiplyer = 2.0f;
	private Vector2 size;

	private Boolean heading = false; //Wenn false --> Rechts // Wenn true --> links


	private Area2D area;

	public override void _Ready()
	{
		area = GetNode<Area2D>("Area2D");
		area.BodyEntered += onPlayerCollision;
		area.AreaEntered += onBulletCollision;
	}

	public override void _PhysicsProcess(double delta)
	{
		changeDirection();
		checkForWall();
		MoveAndSlide();
	}

	private void checkForWall()
	{
		if(IsOnWall()) {
			
			heading = !heading;	
		}
	}

	private void changeDirection()
	{
		if (heading)
		{
			Velocity = new Vector2(-1, 0) * speedMultiplyer;
			return;
		}

		Velocity = new Vector2(1, 0) * speedMultiplyer;
	}

	private void onPlayerCollision(Node2D body)
	{
		SignalManager.EmitLoosing();
	}

	private void onBulletCollision(Area2D otherArea)
	{
		if (otherArea is Bullet)
		{
			this.QueueFree();
			otherArea.QueueFree();	
		}

		heading = !heading;
		GlobalPosition = new Vector2(GlobalPosition.X, GlobalPosition.Y + 32);
		speedMultiplyer *= 1.1f;
	}
	
}
