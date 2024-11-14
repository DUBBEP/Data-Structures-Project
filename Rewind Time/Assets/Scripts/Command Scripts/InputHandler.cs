using Unity.VisualScripting;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;
    Replay replay;
    Invoker invoker;

    public delegate void MakeClone(Replay replay);
    public static event MakeClone OnMakeClone;

    public delegate void StartRecording(PlayerMovement player);
    public static event StartRecording OnStartRecording;

    private void Start()
    {
        replay = new();
        invoker = new();
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            invoker.ExecuteCommand(new Jump(player));

        if (Input.GetKeyDown(KeyCode.R))
            ToggleRecording();

        if (Input.GetKeyDown(KeyCode.P) && CommandLog.recordedCommands.Count > 0)
            OnMakeClone?.Invoke(replay);
    }

    void ToggleRecording()
    {
        if (replay.IsReplaying)
            return;

        if (!invoker.IsRecording)
        {
            OnStartRecording?.Invoke(player);
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
