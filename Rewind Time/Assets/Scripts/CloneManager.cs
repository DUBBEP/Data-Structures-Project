using UnityEngine;

public class CloneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    private Vector3 recordingStartPos;
    private Vector2 recordingStartVelocity;

    void OnEnable()
    {
        InputHandler.OnMakeClone += CreateNewClone;
        InputHandler.OnStartRecording += SetStartInformation;
    }

    void OnDisable()
    {
        InputHandler.OnMakeClone -= CreateNewClone;
        InputHandler.OnStartRecording -= SetStartInformation;
    }


    void SetStartInformation(PlayerMovement originalPlayer)
    {
        recordingStartPos = originalPlayer.transform.position;
        recordingStartVelocity = originalPlayer.rb.velocity;
    }
    void CreateNewClone(Replay replay)
    {
        PlayerMovement playerClone = Instantiate(PlayerPrefab, recordingStartPos, Quaternion.identity).GetComponent<PlayerMovement>();
        playerClone.rb.velocity = recordingStartVelocity;
        replay.StartReplay(playerClone);
    }
}
