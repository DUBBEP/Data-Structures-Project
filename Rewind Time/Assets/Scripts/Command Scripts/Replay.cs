using UnityEngine;

public class Replay : MonoBehaviour
{
    private bool isReplaying;
    public bool IsReplaying { get { return isReplaying; } }
    private float replayStartTime;
    private float replayTime;
    private PlayerMovement replayTarget;



    void FixedUpdate()
    {
        if (isReplaying)
            RunReplay();
    }

    public void StartReplay(PlayerMovement target)
    {
        isReplaying = true;
        replayTarget = target;
    }

    private void RunReplay()
    {
        replayTime += Time.fixedDeltaTime;

        Debug.Log(CommandLog.recordedCommands.Count);

        if (CommandLog.recordedCommands.Count > 0 )
        {
            Command command = CommandLog.recordedCommands.Peek();
            if (replayTime >= command.timeStamp)
            {
                CommandLog.recordedCommands.Dequeue();
                command.controller = replayTarget;
                command.Execute();
            }
        }
        else
        {
            isReplaying = false;
            GameUI.instance.SetReplayStatusText("Idle");
        }
    }
}
