using Godot;
using System;

public partial class SignalManager : Node
{
	public static SignalManager Instance { get; private set; } = new SignalManager();

	[Signal]
	public delegate void ScoreEventHandler(int ammount);

	public static void EmitScore(int ammount)
	{
		Instance.EmitSignal(SignalName.Score, ammount);
	}

	[Signal]
	public delegate void LoosingEventHandler();

	public static void EmitLoosing()
	{
		Instance.EmitSignal(SignalName.Loosing);
	}

	[Signal]
	public delegate void WinningEventHandler();

	public static void EmitWinning()
	{
		Instance.EmitSignal(SignalName.Winning);
	}
}
