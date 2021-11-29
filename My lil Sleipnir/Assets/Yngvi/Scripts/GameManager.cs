using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera main_camera;
    public List<SpriteRenderer> floors = new List<SpriteRenderer>();
    public GameObject floor;
    public float floor_space_between;

    float floor_width;
    SpriteRenderer rm_fl;
    SpriteRenderer new_fl;
    float right_side;

    // Start is called before the first frame update
    void Start()
    {
        floor_width = floors[0].bounds.size.x;
        //Debug.Log(floors[0].bounds.center.x);
        //Debug.Log(floor_width);
    }

    // Update is called once per frame
    void Update()
    {
        rm_fl = null;
        new_fl = null;
        int i = 0;

        foreach (SpriteRenderer fl in floors)
        {
            i++;

            right_side = fl.bounds.center.x + floor_width;

            if (right_side < main_camera.pixelRect.xMin)
                rm_fl = fl;
            if (i == floors.Count && fl.bounds.center.x < main_camera.pixelRect.x)
            {
                Vector3 fl_pos = new Vector3(right_side + floor_space_between, -4, 0);
                // Create new floor and get the spriterenderer of that
                new_fl = Instantiate(floor, fl_pos, Quaternion.identity).GetComponent<SpriteRenderer>();
            }
        }

        if (rm_fl)
        {
            floors.Remove(rm_fl);
            Destroy(rm_fl.gameObject);
        }

        if (new_fl)
            floors.Add(new_fl);
    }
}
