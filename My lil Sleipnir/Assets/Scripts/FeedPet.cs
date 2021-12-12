using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeedPet : MonoBehaviour
{
    [SerializeField] Animator anim;

    private Slider slider;
    private BarFill foodslider;

    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
        foodslider = GameObject.Find("BarFood").GetComponent<BarFill>();
    }
    public void Feed() {
        Debug.Log(slider.value);
        if (GameManager.instance.food_amount >= 1) {
            if (slider.value < 10) {
                foodslider.IncrementProgress(1f);
                GameManager.instance.food_amount -= 1;
            }
            else {
                Debug.Log("Already maxed out the bar");
            }
        }
        else {
            //Debug.Log("Not enough food to feed Sleipnir");
            anim.ResetTrigger("Apples");
            anim.SetTrigger("Apples");
        }
    }
    // Update is called once per frame
    void Update() {
        // Feeding costs 4 coins
    }

}