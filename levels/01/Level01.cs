using Godot;
using System;

public partial class Level01 : Node2D
{
	Timer spawnTimer;
	private int score = 0;
	public override void _Ready()
	{
		//SIGNALS
		SignalManager.Instance.Loosing += loosing;
		SignalManager.Instance.Winning += winning;
		SignalManager.Instance.Score += scoring;

		//TIMER
		spawnTimer = GetNode<Timer>("Timer");
		spawnTimer.Start(0.5);

		spawnTimer.Timeout += OnTimerTimeout;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	private void loosing()
	{
		this.QueueFree();
	}

	private void winning()
	{

	}

	private void scoring(int ammount)
	{
		score += ammount;
		GD.Print(score);
	}

	private void OnTimerTimeout()
	{
		spawnNewEnemy();
		spawnTimer.Start(GD.RandRange(2, 6));
	}

	private void spawnNewEnemy()
	{
		PackedScene enemyScene = GD.Load<PackedScene>("res://scenes/enemie/enemie.tscn");
		Enemie newEnemy = enemyScene.Instantiate<Enemie>();
		AddChild(newEnemy);
		newEnemy.GlobalPosition = new Vector2(Math.Abs(GD.RandRange(64, 1000)), Math.Abs(GD.RandRange(64, 300)));
		newEnemy.speedMultiplyer = (float)GD.RandRange(70.0f, 130.5f);
	}
}
