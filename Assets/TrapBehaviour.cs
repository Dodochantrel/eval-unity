using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class TrapBehaviour : MonoBehaviour
{
    public GameObject Trap;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<DieBehaviour>().killPlayer("Player is dead");
        }
    }
}
