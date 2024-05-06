using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ChangeGravityBehaviour : MonoBehaviour
{
    public GameObject Boost;
    private float negative = -3;
    private float positive = 3;
    private bool isActivated = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
            collision.transform.Rotate(180, 180, 0);
            // Tourner la caméra de 180 180 0
            Camera.main.transform.Rotate(180, 180, 0);
            if (playerRigidbody.gravityScale > 0)
            {
                playerRigidbody.gravityScale = negative;
            }
            else
            {
                playerRigidbody.gravityScale = positive;
            }
            StartCoroutine(disable());
        }
    }

    private IEnumerator disable()
    {
        yield return new WaitForSeconds(5f);
        isActivated = false;
    }
}
