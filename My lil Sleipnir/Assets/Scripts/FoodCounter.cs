using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI foodLabel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foodLabel.text = GameManager.instance.foodAmount.ToString();
    }
}
