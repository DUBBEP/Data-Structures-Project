using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountBehavior : MonoBehaviour
{


    private Vector3 offset = new Vector3(0, 1.1f, 0);
    private bool pauseMount;
    [HideInInspector]
    public bool ridingPlayer;

    private Transform targetMountTransform;

    public bool UpdateMountedPosition(PlayerMovement player)
    {
        if (ridingPlayer)
        {
            transform.position = targetMountTransform.position + offset;
            return true;
        }
        return false;
    }

    public void CheckDismount(PlayerMovement player)
    {
        if (ridingPlayer)
        {
            Dismount(player);
            StartCoroutine(PauseMount());
        }
    }

    public void MountPlayer(PlayerMovement player, Transform otherRB)
    {
        if (pauseMount)
            return;

        player.rb.velocity = Vector2.zero;
        ridingPlayer = true;
        player.rb.isKinematic = true;
        targetMountTransform = otherRB;
    }

    public void Dismount(PlayerMovement player)
    {
        ridingPlayer = false;
        player.rb.isKinematic = false;
        targetMountTransform = null;
    }

    IEnumerator PauseMount()
    {
        pauseMount = true;
        yield return new WaitForSeconds(0.1f);
        pauseMount = false;
    }
}
