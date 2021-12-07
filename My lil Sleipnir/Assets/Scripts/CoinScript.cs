using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void FixedUpdate() {
        if (RunManager.instance.game_started)
            transform.position = new Vector2(transform.position.x - (PlayerScript.instance.player_speed * Time.deltaTime), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
        Destroy(this);
        GameManager.instance.coin_counter++;
    }
}
