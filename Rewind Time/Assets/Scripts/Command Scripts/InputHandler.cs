using Unity.VisualScripting;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;
    
    Replay replay;
    Invoker invoker;


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
            replay.StartReplay(player);
    }

    void ToggleRecording()
    {
        if (replay.IsReplaying)
            return;

        if (!invoker.IsRecording)
        {
            invoker.StartRecording();
            Debug.Log("Recording Started");
            GameUI.instance.SetReplayStatusText("Recording");
        }
        else
        {
            invoker.StopRecording();
            Debug.Log("Recording Stopped");
            GameUI.instance.SetReplayStatusText("Idle");
        }
    }
}
