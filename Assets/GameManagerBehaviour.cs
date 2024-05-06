using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    public static GameManagerBehaviour Instance;
    private int _deathCount;
    public TMP_Text DeathText;
    public GameObject Player;
    public TMP_Text StartText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        StartCoroutine(beforeStart());
    }

    private IEnumerator beforeStart()
    {
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StartText.gameObject.SetActive(true);
        // Récupérer le nom de la scène
        StartText.text = $"Niveau : {SceneManager.GetActiveScene().buildIndex+1}";
        yield return new WaitForSeconds(2);
        StartText.gameObject.SetActive(false);
    }


    public void AddDeath()
    {
        _deathCount++;
        DeathText.text = $"Nombre de morts : {_deathCount}";
    }
}
