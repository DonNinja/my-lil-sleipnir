using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource music;

    private void Awake() {
        instance = this;
        pauseMenuUI.SetActive(false);
    }

    public void Resume() {
        Debug.Log("shouldberesumedc");
        pauseMenuUI.SetActive(false);
        RunManager.instance.game_started = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
        music.volume = 1f;
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        RunManager.instance.game_started = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
        music.volume = .1f;
    }
    public void QuitToStable() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
