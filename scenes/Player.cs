using Godot;
using System;

public partial class Player : Area2D
{
	private Vector2 _screenSize;
	[Export] public int Speed = 300;
	
	private Vector2 _velocity;
	private CollisionPolygon2D _defaultCollisionPoly;
	private CollisionPolygon2D _leftCollisionPoly;
	private CollisionPolygon2D _rightCollisionPoly;


	private AnimatedSprite2D _sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_sprite.Play();
		_sprite.Animation = "default";
		_defaultCollisionPoly = GetNode<CollisionPolygon2D>("DefaultCollisionPoly");
		_leftCollisionPoly = GetNode<CollisionPolygon2D>("LeftCollisionPoly");
		_rightCollisionPoly = GetNode<CollisionPolygon2D>("RightCollisionPoly");
		AreaEntered += OnAreaEntered;	// had to wite this in by hand... seems strange
	}

	public void Initialise(Vector2 screenSize)
	{
		_screenSize = screenSize;
		Position = new Vector2(_screenSize.X * 0.5f, _screenSize.Y * 0.9f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Move((float)delta);
	}

	private void Move(float delta)
	{
		_velocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		_velocity *= Speed * delta;

		Position += _velocity;


		Position = new Vector2(
			Math.Clamp(Position.X, 15, _screenSize.X - 15),
			Math.Clamp(Position.Y, 15, _screenSize.Y - 15)
		);

		if (_velocity.X < 0)
		{
			_sprite.Animation = "left";
			_defaultCollisionPoly.Disabled = true;
			_leftCollisionPoly.Disabled = false;
			_rightCollisionPoly.Disabled = true;
		}
		else if (_velocity.X > 0)
		{
			_sprite.Animation = "right";
			_defaultCollisionPoly.Disabled = true;
			_leftCollisionPoly.Disabled = true;
			_rightCollisionPoly.Disabled = false;
		}
		else
		{
			_sprite.Animation = "default";
			_defaultCollisionPoly.Disabled = false;
			_leftCollisionPoly.Disabled = true;
			_rightCollisionPoly.Disabled = true;
		}


	}

	private void OnAreaEntered(Area2D area)
	{
		if (area.IsInGroup("asteroids"))
		{
			GD.Print("Bang");
		}

	}


	
	
}
