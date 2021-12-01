using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    //public float max_speed;
    public GameObject floor;

    void FixedUpdate() {
        if (GameManager.instance.game_started)
            transform.position = new Vector2(transform.position.x - (PlayerScript.instance.player_speed * Time.deltaTime), transform.position.y);
        // TODO: Potentially add an incremental speed gain
    }
}
