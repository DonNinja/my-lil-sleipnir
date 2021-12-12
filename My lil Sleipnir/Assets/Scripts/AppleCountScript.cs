using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCountScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI apple_label;

    // Update is called once per frame
    void Update() {
        if (GameManager.instance)
            apple_label.text = GameManager.instance.food_amount.ToString();
    }
}
