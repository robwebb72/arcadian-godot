using Godot;
using System;

public partial class Starfield : Node2D
{
	private Vector2 _screenSize;
	[Export] private PackedScene Stars;

	public void Initialise(Vector2 screenSize)
	{
		GD.Print("Initializing Starfield");
		_screenSize = screenSize;
		for (var i = 0; i < 200; i++)
		{
			var star = Stars.Instantiate() as Star;
			star.Initialise(_screenSize);
			AddChild(star);
		}
	}

	// Called when the node enters the scene tree for the first time.



	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
