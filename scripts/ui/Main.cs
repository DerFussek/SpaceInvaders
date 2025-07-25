using Godot;
using System;

public partial class Main : Control
{
	//BUTTONS
	private Button startGame;
	private Button option;
	private Button exit;

	public override void _Ready()
	{
		startGame = GetNode<Button>("VBoxContainer/Start Game");
		option = GetNode<Button>("VBoxContainer/Exit");
		exit = GetNode<Button>("VBoxContainer/Options");

		startGame.Pressed += onStart;
	}

	private void onStart()
	{
		PackedScene levelScene = GD.Load<PackedScene>("res://levels/01/level_01.tscn");
		GetTree().ChangeSceneToPacked(levelScene);
	}

	public override void _Process(double delta)
	{

	}
}
