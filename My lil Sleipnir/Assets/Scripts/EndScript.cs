using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        GameManager.instance.hunger -= Random.Range(0f, 2f);
        GameManager.instance.hygiene -= Random.Range(0f, 5f);
        GameManager.instance.comfort -= Random.Range(0f, 3f);

        SceneManager.LoadSceneAsync("Menu");
    }
}
