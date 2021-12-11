using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePowerups : MonoBehaviour
{
    // Start is called before the first frame update
    public int what_powerup;
    public GameObject checkBox;
    public void ActivatePowerup()
    {
        // add max of 2 powerups active
        if (what_powerup == 1)
        {
            if (checkBox.activeSelf)
            {
                GameManager.instance.is_active_doublejump = false;
                checkBox.gameObject.SetActive(false);
            }
            else
            {
                GameManager.instance.is_active_doublejump = true;
                checkBox.gameObject.SetActive(true);
            }

        }
        if (what_powerup == 2f)
        {
            if (checkBox.activeSelf)
            {
                GameManager.instance.is_active_groundpound = false;
                checkBox.gameObject.SetActive(false);
            }
            else
            {
                GameManager.instance.is_active_groundpound = true;
                checkBox.gameObject.SetActive(true);
            }

        }
        if (what_powerup == 3)
        {
            if (checkBox.activeSelf)
            {
                GameManager.instance.is_active_neverdirty = false;
                checkBox.gameObject.SetActive(false);
            }
            else
            {
                GameManager.instance.is_active_neverdirty = true;
                checkBox.gameObject.SetActive(true);
            }

        }
        if (what_powerup == 4)
        {
            if (checkBox.activeSelf)
            {
                GameManager.instance.is_active_alwaysloves = false;
                checkBox.gameObject.SetActive(false);
            }
            else
            {
                GameManager.instance.is_active_alwaysloves = true;
                checkBox.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
