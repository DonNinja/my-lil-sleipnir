using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI currencyLabel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currencyLabel.text = "Coins: " + GameManager.instance.currency.ToString();
    }
}