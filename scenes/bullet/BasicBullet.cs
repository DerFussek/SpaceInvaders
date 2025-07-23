using Godot;

public partial class BasicBullet : Area2D
{
	// Called when the node enters the scene tree for the first time.GlobalPosition = position;
	public float speedMultiplyer = 1f;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 speedVector = new Vector2(0, -1) * this.speedMultiplyer;
		Position += speedVector * (float)delta;

		if (GlobalPosition.Y >= 0) QueueFree();
	}
}
