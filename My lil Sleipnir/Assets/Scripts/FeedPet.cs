using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeedPet : MonoBehaviour
{
    // Start is called before the first frame update

    private Slider slider;
    private BarFill foodslider;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        foodslider = GameObject.Find("FoodBar").GetComponent<BarFill>();

    }
    void Start()
    {

    }
    public void Feed()
    {
        if (GameManager.instance.foodAmount >= 1)
        {
            foodslider.IncrementProgress(0.1f);
            GameManager.instance.foodAmount -= 1;
        }
        else
        {
            Debug.Log("Not enough food to feed Sleipnir");
            // Add func that highlights your coins showing the player you don't have enough
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Feeding costs 4 coins
    }

}