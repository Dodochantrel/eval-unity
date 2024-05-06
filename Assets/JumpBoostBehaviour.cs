using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class JumpBoostBehaviour : MonoBehaviour
{
    public GameObject Boost;
    public float NewJumpForce;
    private float _jumpForceBefore;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _jumpForceBefore = collision.GetComponent<PlayerBehaviour>().JumpForce;
            collision.GetComponent<PlayerBehaviour>().JumpForce = NewJumpForce;
            StartCoroutine(disable(collision));
        }
    }

    private IEnumerator disable(Collider2D collision)
    {
        yield return new WaitForSeconds(10);
        collision.GetComponent<PlayerBehaviour>().JumpForce = _jumpForceBefore;
    }
}
