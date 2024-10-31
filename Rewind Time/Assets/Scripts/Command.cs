using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Rigidbody playerBody;
    public float timeStamp;
    public abstract void Execute();
}

class MoveLeft : Command
{
    private float forceValue;

    public MoveLeft(Rigidbody player, float force)
    {
        playerBody = player;
        forceValue = force;
    }

    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        playerBody.AddForce(-forceValue * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}

class MoveRight : Command
{
    private float forceValue;

    public MoveRight(Rigidbody player, float force)
    {
        playerBody = player;
        forceValue = force;
    }

    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        playerBody.AddForce(forceValue * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}

class MoveUp : Command
{
    private float forceValue;

    public MoveUp(Rigidbody player, float force)
    {
        playerBody = player;
        forceValue = force;
    }

    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        playerBody.AddForce(0 ,forceValue * Time.deltaTime, 0, ForceMode.VelocityChange);
        
    }
}
public static class CommandLog
{
    public static Queue<Command> commands1 = new Queue<Command>();
    //public static Queue<Command> commands2 = new Queue<Command>(); //attempt at new feature
}