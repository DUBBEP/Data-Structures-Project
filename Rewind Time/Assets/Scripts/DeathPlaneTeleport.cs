using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = Vector3.zero;
    }
}
