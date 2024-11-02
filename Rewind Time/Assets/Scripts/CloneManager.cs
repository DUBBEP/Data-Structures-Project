using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    private Vector3 recordingStartPos;

    void OnEnable()
    {
        InputHandler.OnMakeClone += CreateNewClone;
        InputHandler.OnStartRecording += SetStartPosition;
    }

    void OnDisable()
    {
        InputHandler.OnMakeClone -= CreateNewClone;
        InputHandler.OnStartRecording -= SetStartPosition;
    }


    void SetStartPosition(Vector3 startPos)
    {
        recordingStartPos = startPos;
    }
    void CreateNewClone(Replay replay)
    {
        PlayerMovement playerClone = Instantiate(PlayerPrefab, recordingStartPos, Quaternion.identity).GetComponent<PlayerMovement>();
        replay.StartReplay(playerClone);
    }
}
