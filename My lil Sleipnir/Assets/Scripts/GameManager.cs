using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coin_counter = 0;
    public int food_amount = 0;
    public int score;
    public bool owns_doublejump;
    public bool owns_groundpound;
    public bool owns_neverdirty;
    public bool owns_alwaysloves;
    public bool is_active_doublejump;
    public bool is_active_groundpound;
    public bool is_active_neverdirty;
    public bool is_active_alwaysloves;

    public Slider hunger_slider;
    public float hunger;
    public Slider hygiene_slider;
    public float hygiene;
    public Slider comfort_slider;
    public float comfort;

    public bool in_stables;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        if (hunger_slider)
            hunger = hunger_slider.value;
        if (hygiene_slider)
            hygiene = hygiene_slider.value;
        if (comfort_slider)
            comfort = comfort_slider.value;

        score = 0;
    }

    public void EndGame()
    {
        hunger -= 2;
        if (!is_active_neverdirty)
            hygiene -= 1;
        if (!is_active_alwaysloves)
            comfort -= 1;

        SceneManager.LoadSceneAsync("MenuFinal");
    }
}
