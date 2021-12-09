using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coin_counter = 0;
    public int food_amount;
    public int score;
    public int final_score;

    public Slider hunger_slider;
    public float hunger;
    public Slider hygiene_slider;
    public float hygiene;
    public Slider comfort_slider;
    public float comfort;

    public bool in_stables;

    private void Awake()
    {
        hunger = hunger_slider.value;
        hygiene = hygiene_slider.value;
        comfort = comfort_slider.value;

        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
