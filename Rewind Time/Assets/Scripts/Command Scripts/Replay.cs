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
        GameUI.instance.SetReplayStatusText("Replaying");
        isReplaying = true;
        replayTarget = target;
        replayTime = 0;
    }

    private void RunReplay()
    {
        replayTime += Time.fixedDeltaTime;
        bool commandsInQueue = CommandLog.recordedCommands.Count > 0;

        if (commandsInQueue)
        {
            Command command = CommandLog.recordedCommands.Peek();

            Debug.Log("Command Time Stamp: " + command.timeStamp + " VS ReplayTime: " + replayTime);
            if (replayTime >= command.timeStamp)
            {
                CommandLog.recordedCommands.Dequeue();
                CommandLogTracker.Instance.UpdateCountText();
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
