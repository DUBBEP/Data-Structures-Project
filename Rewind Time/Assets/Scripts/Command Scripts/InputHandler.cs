using Unity.VisualScripting;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    Invoker invoker;
    [SerializeField]
    PlayerMovement player;
    Replay replay;


    private void Start()
    {
        replay = this.AddComponent<Replay>();
        invoker = this.AddComponent<Invoker>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            invoker.ExecuteCommand(new MoveLeft(player));
        else if (Input.GetKey(KeyCode.D))
            invoker.ExecuteCommand(new MoveRight(player));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            invoker.ExecuteCommand(new Jump(player));

        if (Input.GetKeyDown(KeyCode.R))
            ToggleRecording();
        
        if (Input.GetKeyDown(KeyCode.P))
            RunReplay();
    }

    void RunReplay()
    {
        replay.StartReplay(player);
        GameUI.instance.SetReplayStatusText("Replaying");
    }


    void ToggleRecording()
    {
        if (replay.IsReplaying)
            return;

        if (!invoker.IsRecording)
        {
            invoker.StartRecording();
            GameUI.instance.SetReplayStatusText("Recording");
            Debug.Log("Recording Started");
        }
        else
        {
            invoker.StopRecording();
            Debug.Log("Recording Stopped");
            GameUI.instance.SetReplayStatusText("Idle");
        }
    }
}
