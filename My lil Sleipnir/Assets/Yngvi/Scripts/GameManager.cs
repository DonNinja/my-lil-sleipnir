using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera main_camera;
    public List<SpriteRenderer> floors = new List<SpriteRenderer>();
    public GameObject new_floor;
    public float floor_interval;

    float floor_width;
    SpriteRenderer rm_fl_sr;
    SpriteRenderer new_fl_sr;
    float right_side;

    // Start is called before the first frame update
    void Start()
    {
        floor_width = floors[0].bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        rm_fl_sr = null;
        new_fl_sr = null;
        int i = 0;

        foreach (SpriteRenderer fl in floors)
        {
            i++;

            right_side = fl.bounds.center.x + floor_width;

            if (right_side < main_camera.pixelRect.xMin)
                rm_fl_sr = fl;

            if (i == floors.Count && fl.bounds.center.x < main_camera.pixelRect.x)
            {
                Vector3 floor_pos = new Vector3(right_side + floor_interval, -4, 0);
                // Create new floor and get the spriterenderer of that
                GameObject fl_child = Instantiate(new_floor, floor_pos, Quaternion.identity);
                new_fl_sr = fl_child.gameObject.transform.Find("Floor").GetComponent<SpriteRenderer>();
                new_fl_sr.color = Random.ColorHSV();
            }
        }

        if (rm_fl_sr)
        {
            floors.Remove(rm_fl_sr);
            Destroy(rm_fl_sr.transform.parent.gameObject);
        }

        if (new_fl_sr)
            floors.Add(new_fl_sr);
    }
}
