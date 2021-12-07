using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] GameObject horse;

    void OnCollisionEnter2D(Collision2D collision) {
        // TODO: Crash horse
        UnityEditor.EditorApplication.isPlaying = false;
        //horse.GetComponent<Collider2D>().enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        //Rigidbody2D horse_rigid = horse.GetComponent<Rigidbody2D>();
        //horse_rigid.velocity = Random.insideUnitCircle.normalized * 20f;
        //horse_rigid.mass = 0f;
        //horse_rigid.rotation = Random.Range(1f, 180f);
        //PlayerScript.instance.player_speed = 0;
        //horse_rigid.gravityScale = 0f;
    }
}
