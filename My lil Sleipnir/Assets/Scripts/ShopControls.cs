using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShopUI;

    // public bool hasDoubleJump;
    // public bool hasGroundpound;
    // public bool hasAlwayslove;
    // public bool hasNeverdirty;
    // Prices
    private int applePrice = 4;
    // private int DoublejumpPrice = 100;
    // private int GroundpoundPrice = 100;
    // private int AlwayslovePrice = 100;
    // private int NeverdirtyPrice = 100;

    public void showShop()
    {
        if (ShopUI.activeSelf)
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
        if (GameManager.instance.coin_counter >= applePrice)
        {
            GameManager.instance.food_amount += 1;
            GameManager.instance.coin_counter -= applePrice;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
    public void buyFoodbag()
    {
        if (GameManager.instance.coin_counter >= applePrice * 5)
        {
            GameManager.instance.food_amount += 5;
            GameManager.instance.coin_counter -= applePrice * 5;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
}
