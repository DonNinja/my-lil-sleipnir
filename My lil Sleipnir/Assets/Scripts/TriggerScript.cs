using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        PlayerScript.instance.player_speed = 0;
    }
}
