using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public float player_speed;
    public float max_speed;
    public float interval;
    public Rigidbody2D floor;

    // Start is called before the first frame update
    void Start()
    {
        floor.velocity = new Vector2(-player_speed, 0);
    }

    void Update()
    {
        
    }
}
