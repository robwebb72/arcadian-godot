using Godot;
using System;

public partial class Main : Node2D
{
	private Vector2 _screenSize;
	private Starfield _starfield;
	private Player _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screenSize = GetViewport().GetVisibleRect().Size;
		_starfield = GetNode<Starfield>("Starfield");
		_player = GetNode<Player>("Player");
		_starfield.Initialise(_screenSize);
		_player.Initialise(_screenSize);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
