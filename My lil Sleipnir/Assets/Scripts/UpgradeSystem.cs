using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class UpgradeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activatedToggle;
    public GameObject deactivatedToggle;
    //public GameObject powerupActivated;
    private int doublejump_price = 50;
    private int groundpound_price = 50;
    private int neverdirty_price = 50;
    private int alwaysloves_price = 50;

    public int what_powerup;

    private void Start()
    {
        if (what_powerup == 1)
        {
            if (GameManager.instance.owns_doublejump == true)
            {
                deactivatedToggle.SetActive(false);
                activatedToggle.SetActive(true);
            }

        }
        if (what_powerup == 2)
        {
            if (GameManager.instance.owns_groundpound == true)
            {
                deactivatedToggle.SetActive(false);
                activatedToggle.SetActive(true);
            }

        }
        if (what_powerup == 3)
        {
            if (GameManager.instance.owns_neverdirty == true)
            {
                deactivatedToggle.SetActive(false);
                activatedToggle.SetActive(true);
            }

        }
        if (what_powerup == 4)
        {
            if (GameManager.instance.owns_alwaysloves == true)
            {
                deactivatedToggle.SetActive(false);
                activatedToggle.SetActive(true);
                GameManager.instance.comfort = 10;
            }
        }
    }

    public void buyPowerupDoubleJump()
    {
        if (GameManager.instance.coin_counter >= doublejump_price)
        {
            //hasDoubleJump = true;
            //GameObject.Find("doubleJumpDeactivatedToggle").SetActive(false);
            deactivatedToggle.SetActive(false);
            activatedToggle.SetActive(true);
            //GameObject.Find("doubleJumpActivatedToggle").SetActive(true);
            GameManager.instance.coin_counter -= doublejump_price;
            GameManager.instance.owns_doublejump = true;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
    public void buyPowerupGroundPound()
    {
        if (GameManager.instance.coin_counter >= groundpound_price)
        {
            //hasDoubleJump = true;
            //GameObject.Find("doubleJumpDeactivatedToggle").SetActive(false);
            deactivatedToggle.SetActive(false);
            activatedToggle.SetActive(true);
            //GameObject.Find("doubleJumpActivatedToggle").SetActive(true);
            GameManager.instance.coin_counter -= groundpound_price;
            GameManager.instance.owns_groundpound = true;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
    public void buyPowerupNeverDirty()
    {
        if (GameManager.instance.coin_counter >= neverdirty_price)
        {
            //hasDoubleJump = true;
            //GameObject.Find("doubleJumpDeactivatedToggle").SetActive(false);
            deactivatedToggle.SetActive(false);
            activatedToggle.SetActive(true);
            //GameObject.Find("doubleJumpActivatedToggle").SetActive(true);
            GameManager.instance.coin_counter -= neverdirty_price;
            GameManager.instance.owns_neverdirty = true;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
    public void buyPowerupAlwaysLoves()
    {
        if (GameManager.instance.coin_counter >= alwaysloves_price)
        {
            //hasDoubleJump = true;
            //GameObject.Find("doubleJumpDeactivatedToggle").SetActive(false);
            deactivatedToggle.SetActive(false);
            activatedToggle.SetActive(true);
            //GameObject.Find("doubleJumpActivatedToggle").SetActive(true);
            GameManager.instance.coin_counter -= alwaysloves_price;
            GameManager.instance.owns_alwaysloves = true;
        }
        else
        {
            // Send a message to the player that he can't afford and should go collect coins on a run
            // For now just debuglog it
            Debug.Log("Can't afford that right now");
        }
    }
}
