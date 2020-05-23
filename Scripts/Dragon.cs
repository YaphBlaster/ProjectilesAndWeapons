using Godot;
using System;

public class Dragon : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Loading a Scene Instance with C#

    PackedScene FireballScene = ResourceLoader.Load<PackedScene>("res://Scenes/Fireball.tscn");

    // Create Timer Variable;
    Timer Timer;
    const float Speed = 100f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Initialize Timer variable to Timer node
        Timer = GetNode<Timer>("Timer");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        float speedY = 0;

        // Up Key
        if (Input.IsActionPressed("ui_up"))
        {
            // Set the Y Speed Value to the negative of the Speed Constant
            speedY = -Speed;
        }
        // Down Key
        else if (Input.IsActionPressed("ui_down"))
        {
            // Set the Y Speed Value to the Speed Constant
            speedY = Speed;
        }

        // Set the position of the Dragon
        Position += new Vector2(0, speedY) * delta;

        if (Input.IsActionPressed("ui_accept"))
        {
            // If the timer has been stopped
            // This is used to limit the amount of fireballs that will be created per frame
            if (Timer.IsStopped())
            {
                // Create the fireball
                CreateFireball();
                // Restart the Timer
                RestartTimer();
            }
        }
    }

    public void CreateFireball()
    {
        // Create an instance of the Fireball Scene
        Area2D fireball = (Area2D)FireballScene.Instance();

        // Add the Fireball to the Scene
        // GetParent() gets the World Node since the Dragon is a child of the World Scene
        GetParent().AddChild(fireball);
        fireball.Position = GetNode<Position2D>("FireballAnchor").GlobalPosition;
    }

    public void RestartTimer()
    {
        // Set the WaitTime to 0.5f
        Timer.WaitTime = 0.5f;

        // Start the Timer again
        Timer.Start();
    }

    // Timeout Signal connecting Method
    public void _on_Timer_timeout()
    {
        // When the Timer has finished, stop the timer
        Timer.Stop();
    }
}
