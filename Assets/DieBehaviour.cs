using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DieBehaviour : MonoBehaviour
{
    public GameObject Player;
    public void killPlayer(string message)
    {
        // debug
        Debug.Log(message);
        GameManagerBehaviour.Instance.AddDeath();
        // Is trigger de player a true
        Player.GetComponent<BoxCollider2D>().isTrigger = true;
        // désactiver les rotations
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        // Mettre toute les rotation a 0
        Player.GetComponent<PlayerBehaviour>().enabled = false;
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        Player.GetComponent<PlayerBehaviour>().enabled = true;
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        // Remettre les rotations à zéro
        Player.transform.rotation = Quaternion.identity;
        Camera.main.transform.rotation = Quaternion.identity;
        Player.GetComponent<PlayerBehaviour>().JumpForce = 500;
        Player.GetComponent<PlayerBehaviour>().Speed = 10;
        Player.transform.position = new Vector3(-10, 0.5f, 0);
        Player.GetComponent<Rigidbody2D>().gravityScale = 3;
        Player.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
