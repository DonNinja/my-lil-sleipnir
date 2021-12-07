using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public static RunManager instance;
    public Camera main_camera;
    public List<GameObject> floors = new List<GameObject>();
    public GameObject new_floor;
    public bool game_started;
    public bool generate_level;
    public float floor_interval;
    public float start_time;
    public SpriteRenderer test_obj;

    SpriteRenderer rm_fl_sr;
    SpriteRenderer new_fl_sr;
    float floor_width;
    float right_side;
    float init_time;


    void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        rm_fl_sr = null;
        new_fl_sr = null;

        //if (generate_level) {

            //// Get the right side of the camera
            //float camera_right = main_camera.ScreenToWorldPoint(new Vector3(main_camera.pixelRect.xMax, 0, 0)).x + main_camera.transform.position.x;

            //// TODO: Make this dynamic so we don't require the player to stay in x coords 0 (This isn't ultimately required, but would be nice)
            //float camera_left = main_camera.ScreenToWorldPoint(new Vector3(main_camera.pixelRect.xMax - main_camera.pixelRect.xMax, 0, 0)).x + main_camera.transform.position.x;

            //foreach (SpriteRenderer fl in floors) {
            //    i++;

            //    right_side = fl.bounds.center.x + floor_width;

            //    if (right_side < camera_left)
            //        rm_fl_sr = fl;

            //    if (i == floors.Count && right_side < camera_right) {
            //        Vector3 floor_pos = new Vector3(right_side + floor_width + floor_interval, new_floor.transform.position.y, 0);

            //        // Create new floor and get the spriterenderer of that
            //        GameObject fl_child = Instantiate(new_floor, floor_pos, Quaternion.identity);

            //        new_fl_sr = fl_child.gameObject.transform.Find("Floor").Find("Floor").GetComponent<SpriteRenderer>();
            //        new_fl_sr.color = Random.ColorHSV();
            //        floor_width = new_fl_sr.bounds.extents.x;
            //    }
            //}

            //if (rm_fl_sr) {
            //    floors.Remove(rm_fl_sr);
            //    Destroy(rm_fl_sr.transform.parent.gameObject);
            //}

            //if (new_fl_sr)
            //    floors.Add(new_fl_sr);
        //}
    }
}
