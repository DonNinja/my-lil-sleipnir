using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (GameManager.instance)
            GameManager.instance.food_amount++;
    }
}
