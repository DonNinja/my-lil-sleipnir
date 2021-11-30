using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    //public float max_speed;
    public GameObject floor;

    void FixedUpdate()
    {
        floor.transform.position = new Vector2(floor.transform.position.x - (PlayerScript.instance.player_speed * Time.deltaTime), floor.transform.position.y);
        // TODO: Potentially add an incremental speed gain
    }
}
