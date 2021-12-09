using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public static RunManager instance;
    public bool game_started;

    [SerializeField] GameObject last_section;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> floor_collection;
    [SerializeField] List<GameObject> generated_floors;

    readonly float IN_CAMERA_DIST = 40f;

    void Awake() {
        instance = this;
    }

    void Start() {
        generated_floors.Add(last_section);
    }

    // Update is called once per frame
    void Update() {
        Vector2 end_pos = last_section.transform.Find("End").position;
        Debug.Log(end_pos);
        if (Vector2.Distance(player.transform.position, end_pos) < Camera.main.transform.position.x + IN_CAMERA_DIST) {
            GenerateNewSection(end_pos);
        }

        if (generated_floors[0].gameObject.transform.Find("End").position.x < Camera.main.transform.position.x - IN_CAMERA_DIST) {
            Destroy(generated_floors[0].gameObject);
            generated_floors.RemoveAt(0);
        }
    }

    void GenerateNewSection(Vector2 position) {
        int i = Random.Range(0, floor_collection.Count);
        GameObject floor = floor_collection[i];
        last_section = Instantiate(floor, position, Quaternion.identity);
        generated_floors.Add(last_section);
    }
}
