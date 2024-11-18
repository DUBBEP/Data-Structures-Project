using UnityEngine;

public class CloneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Sprite cloneSprite;
    [SerializeField]
    private GameObject spawnParticlePrefab;

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
        GameObject particles = Instantiate(spawnParticlePrefab, recordingStartPos, Quaternion.identity);
        Destroy(particles, 10f);

        PlayerMovement playerClone = Instantiate(playerPrefab, recordingStartPos, Quaternion.identity).GetComponent<PlayerMovement>();
        playerClone.rb.velocity = recordingStartVelocity;
        playerClone.GetComponentInChildren<SpriteRenderer>().sprite = cloneSprite;
        replay.StartReplay(playerClone);


    }
}
