using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer sp;
    

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerScript.instance.coin_get_sound.Play();
        if (GameManager.instance)
            GameManager.instance.coin_counter++;
        Destroy(gameObject);
        Destroy(this);
        //gameObject.SetActive(false);
        //GetComponent<SpriteRenderer>().gameObject.SetActive(false);
        //sp.enabled = false;
        //sp.color = new Color(0, 0, 0, 0);
    }
}
