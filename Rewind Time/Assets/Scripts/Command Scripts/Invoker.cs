using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool isRecording;
    public bool IsRecording { get { return isRecording; } }
    private float recordingTime;
    private float replayStartTime;

    void FixedUpdate()
    {
        if (isRecording)
            recordingTime += Time.deltaTime;
    }

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (isRecording)
        {
            command.timeStamp = recordingTime;
            CommandLog.recordedCommands.Enqueue(command);

            Debug.Log("Recorded Time: " + command.timeStamp);
        }
        Debug.Log("Executed Command: " + command);
    }

    public void StartRecording()
    {
        Debug.Log("Starting Recording");
        recordingTime = 0.0f;
        isRecording = true;
    }
    public void StopRecording()
    {
        isRecording = false;
    }
}

