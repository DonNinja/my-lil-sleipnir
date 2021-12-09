using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public GameObject RecapUI;
    public GameObject KillHorse;
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.hunger -= Random.Range(0f, 2f);
        GameManager.instance.hygiene -= Random.Range(0f, 5f);
        GameManager.instance.comfort -= Random.Range(0f, 3f);

        Time.timeScale = 0;
        // GameManager.instance.final_score = GameManager.instance.score;
        RecapUI.gameObject.SetActive(true);
        KillHorse.gameObject.SetActive(false);
        GameObject.Find("RunManager").GetComponent<RunManager>().game_end = true;
        GameObject.Find("HighScoreTable").GetComponent<HighScoreTable>().AddHighscoreEntry(GameManager.instance.score);
        //SceneManager.LoadSceneAsync("Menu");
    }
    public void changeToStables()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
