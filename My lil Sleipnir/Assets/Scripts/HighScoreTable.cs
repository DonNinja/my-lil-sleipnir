using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreTable : MonoBehaviour
{
    // Start is called before the first frame update
    public static HighScoreTable instance;
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreDefaultList;
    private void Start()
    {
        entryContainer = GameObject.Find("highscoreContainer").transform;
        entryTemplate = entryContainer.Find("highscoreTemplate");

        entryTemplate.gameObject.SetActive(false);





        // highscoreEntryList = new List<HighscoreEntry>() {
        //     new HighscoreEntry{ score = 100},
        //     new HighscoreEntry{ score = 200},
        //     new HighscoreEntry{ score = 300},
        //     new HighscoreEntry{ score = 400},
        //     new HighscoreEntry{ score = 500},
        // };
        if (PlayerPrefs.HasKey("highscoreTable") == false)
        {
            highscoreDefaultList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 100},
            new HighscoreEntry{ score = 200},
            new HighscoreEntry{ score = 300},
            new HighscoreEntry{ score = 400},
            new HighscoreEntry{ score = 500},
        };
            Highscores defaultHighscores = new Highscores { highscoreEntryList = highscoreDefaultList };
            string json = JsonUtility.ToJson(defaultHighscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        // Sort from highest to lowest
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }

        }
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        // Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        // string json = JsonUtility.ToJson(highscores);
        // PlayerPrefs.SetString("highscoreTable", json);
        // PlayerPrefs.Save();
        // Debug.Log(PlayerPrefs.GetString("highscoreTable"));

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 120f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        int score = highscoreEntry.score;
        entryTransform.Find("posText").GetComponent<TMPro.TextMeshPro>().text = rankString;
        entryTransform.Find("scoreText").GetComponent<TMPro.TextMeshPro>().text = score.ToString();

        transformList.Add(entryTransform);

    }

    public void AddHighscoreEntry(int score)
    {
        // Create a new highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };

        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to highscore
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Sort to check if it belongs on top 5
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }

        }

        // remove the 6th element
        if (highscores.highscoreEntryList.Count > 5)
        {
            highscores.highscoreEntryList.RemoveAt(highscores.highscoreEntryList.Count - 1);
        }

        // save
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);

        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
    }

    public void changeToStables()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
