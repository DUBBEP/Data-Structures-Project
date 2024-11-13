public enum Direction
{
    left,
    right,
}
public abstract class Command
{
    public PlayerMovement controller;
    public float timeStamp;

    public abstract void Execute();
}

public class MoveLeft : Command
{
    public MoveLeft(PlayerMovement targetPlayer)
    {
        controller = targetPlayer;
    }

    public override void Execute()
    {
        controller.Move(Direction.left);
    }
}
public class MoveRight : Command
{
    public MoveRight(PlayerMovement targetPlayer)
    {
        controller = targetPlayer;
    }

    public override void Execute()
    {
        controller.Move(Direction.right);
    }
}
public class Jump : Command
{
    public Jump(PlayerMovement targetPlayer)
    {
        controller = targetPlayer;
    }

    public override void Execute()
    {
        controller.TryJump();
    }
}