using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public GameObject floor;

    void FixedUpdate() {
        if (RunManager.instance.game_started)
            transform.position = new Vector2(transform.position.x - (PlayerScript.instance.player_speed * Time.deltaTime), transform.position.y);
    }
}
