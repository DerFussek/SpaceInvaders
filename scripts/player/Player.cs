using Godot;

public partial class Player : CharacterBody2D
{
	[Export(PropertyHint.Link)]
	private Vector2 speed = new(200, 0);

	public override void _PhysicsProcess(double delta)
	{
		handleInput();
		MoveAndSlide();
	}

	private void checkForWall() {
		
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
