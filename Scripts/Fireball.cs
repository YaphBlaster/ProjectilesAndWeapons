using Godot;
using System;

public class Fireball : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    const float Speed = 200;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        float speedX = 1f;
        float speedY = 0f;
        Vector2 motion = new Vector2(speedX, speedY) * Speed;
        Position += motion * delta;
    }

    public void _on_VisibilityNotifier2D_screen_exited()
    {
        // Destroy fireball on the next available frame
        QueueFree();
    }

    // Signal called when the Fireball's Area interacts with a external Area
    // param: Area - external area that will be collided with
    public void _on_Fireball_area_entered(Area2D area)
    {
        QueueFree();
        area.QueueFree();
    }

}
