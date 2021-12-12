using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] GameObject horse;

    void OnCollisionEnter2D(Collision2D collision) {
        PlayerScript.instance.player_speed = 0f;
        if (GameManager.instance) {
            GameManager.instance.EndGame();
        }
    }
}
