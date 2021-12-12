using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (GameManager.instance)
            GameManager.instance.food_amount++;
        Destroy(gameObject);
        Destroy(this);
    }
}
