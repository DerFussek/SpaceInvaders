using Godot;
using System;

public partial class Level01 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//SIGNALS
		SignalManager.Instance.Loosing += loosing;
		SignalManager.Instance.Winning += winning;
		SignalManager.Instance.Score += scoring;
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
		
	}
}
