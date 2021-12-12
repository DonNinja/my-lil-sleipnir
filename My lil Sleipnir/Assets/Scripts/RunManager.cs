using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager instance;
    public bool game_started;
    public GameObject highScoreUI;

    [SerializeField] GameObject last_section;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> floor_collection;
    [SerializeField] List<GameObject> floor_collection_left;
    [SerializeField] List<GameObject> generated_floors;
    [SerializeField] float IN_CAMERA_DIST;

    string last_section_name;

    void Awake()
    {
        instance = this;
        game_started = true;
        floor_collection_left = new List<GameObject>(floor_collection);
        GameManager.instance.coin_run_counter = 0;
        GameManager.instance.score = 0;
        GameManager.instance.times_died = 0;
    }

    void Start()
    {
        generated_floors.Add(last_section);
    }

    // Update is called once per frame
    void Update()
    {
        if (game_started)
        {
            GameManager.instance.score++;
        }

        if (Input.GetKeyDown(KeyCode.P))
            if (game_started)
                PauseMenu.instance.Pause();
            else
                PauseMenu.instance.Resume();

        if (floor_collection_left.Count == 0)
        {
            floor_collection_left = new List<GameObject>(floor_collection);
        }
        Vector2 end_pos = last_section.transform.Find("End").position;
        if (Vector2.Distance(player.transform.position, end_pos) < Camera.main.transform.position.x + IN_CAMERA_DIST)
        {
            GenerateNewSection(end_pos);
        }

        if (generated_floors[0].gameObject.transform.Find("End").position.x < Camera.main.transform.position.x - IN_CAMERA_DIST)
        {
            Destroy(generated_floors[0].gameObject);
            generated_floors.RemoveAt(0);
        }
    }

    void GenerateNewSection(Vector2 position)
    {
        int i = Random.Range(0, floor_collection_left.Count);
        GameObject floor = floor_collection_left[i];
        last_section = Instantiate(floor, position, Quaternion.identity);
        last_section_name = floor.name;
        generated_floors.Add(last_section);
        floor_collection_left.RemoveAt(i);
    }
    public void EndGame()
    {
        game_started = false;
        //highScoreTableUI.gameObject.GetComponent<HighScoreTable>().AddHighscoreEntry(GameManager.instance.score);
        highScoreUI.gameObject.SetActive(true);
        GameObject.Find("HighScoreTable").GetComponent<HighScoreTable>().AddHighscoreEntry(GameManager.instance.score);
        Debug.Log("This is activated");


    }
}
