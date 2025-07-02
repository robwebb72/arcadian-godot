using Godot;
using System;

public partial class Star : Sprite2D
{
	private Vector2 _screenSize;
	private int _speed;

	public void Initialise(Vector2 screenSize)
	{
		_screenSize = screenSize;
		Position = new Vector2(
			(int)GD.RandRange(0, screenSize.X),
			(int)GD.RandRange(0, screenSize.Y)
		);
		ResetSpeed();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(0, (float)delta * _speed);
		if (Position.Y > _screenSize.Y)
		{
			Position = new Vector2((int)GD.RandRange(0, _screenSize.X), 0);
			ResetSpeed();
		}
	}

	private void ResetSpeed()
	{
		_speed = GD.RandRange(50, 192);
	}
}
