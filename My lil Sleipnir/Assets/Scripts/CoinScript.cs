using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
        Destroy(this);
        GameManager.instance.coin_counter++;
    }
}