using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score_label;

    // Update is called once per frame
    void Update()
    {
        score_label.text = GameManager.instance.score.ToString();
    }
}
