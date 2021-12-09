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
        if (ShopUI.gameObject.activeSelf)
        {
            ShopUI.gameObject.SetActive(false);
        }
        else
        {
            ShopUI.gameObject.SetActive(true);
        }
    }
    public void exitButton()
    {
        ShopUI.gameObject.SetActive(false);
    }

    public void buyFood()
    {
        if (GameManager.instance.coin_counter >= 4)
        {
            GameManager.instance.food_amount += 1;
            GameManager.instance.coin_counter -= 4;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
}
