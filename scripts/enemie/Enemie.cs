using Godot;
using System;

public partial class Enemie : CharacterBody2D
{
	[Export]
	public float speedMultiplyer { get; set; } = 2.0f;   //Movementspeed
	private Vector2 size; //Viewport size
	private Boolean heading = false; //Wenn false --> Rechts // Wenn true --> links
	private Area2D area; //For Collision

	public override void _Ready()
	{
		area = GetNode<Area2D>("Area2D");
		area.BodyEntered += onPlayerCollision;
		area.AreaEntered += onAreaCollision;
	}

	public override void _PhysicsProcess(double delta)
	{
		changeDirection(); //Calculate Movement
		MoveAndSlide(); //Apply Movement
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

	private void onAreaCollision(Area2D otherArea)
	{
		if (otherArea is Bullet) //If it isn't a Bullet it must be the Wall
		{
			SignalManager.EmitScore(1);
			this.QueueFree(); //Kill the ENemy
			otherArea.QueueFree();  //Kill the colliding Bullet
		}

		//Action for colliding with the Wall
		heading = !heading; //Change direction
		GlobalPosition = new Vector2(GlobalPosition.X, GlobalPosition.Y + 32); //Move down
		speedMultiplyer *= 1.1f; //increase Speed by 10%
		
	}	
}
