using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coin_label;

    // Update is called once per frame
    void Update() {
        if (GameManager.instance)
            coin_label.text = GameManager.instance.coin_counter.ToString();
    }
}
