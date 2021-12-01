using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    private Slider foodBar;
    private Slider cleanBar;
    private Slider affectionBar;
    private float happinessValue;
    public float fillSpeed = 0.5f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        foodBar = GameObject.Find("FoodBar").GetComponent<Slider>();
        cleanBar = GameObject.Find("CleanBar").GetComponent<Slider>();
        affectionBar = GameObject.Find("AffectionBar").GetComponent<Slider>();
    }
    void Start()
    {
        happinessValue = foodBar.value + cleanBar.value + affectionBar.value;
    }

    // Update is called once per frame
    void Update()
    {
        happinessValue = foodBar.value + cleanBar.value + affectionBar.value;

        if (slider.value < happinessValue)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
    }
}
