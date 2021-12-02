using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShopUI;

    public void showShop()
    {
        ShopUI.gameObject.SetActive(true);
    }
    public void exitButton()
    {
        ShopUI.gameObject.SetActive(false);
    }

    public void buyFood()
    {
        if (GameManager.instance.currency >= 4)
        {
            GameManager.instance.foodAmount += 1;
            GameManager.instance.currency -= 4;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
