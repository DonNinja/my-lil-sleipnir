using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public float player_speed;
    public float jump_height;
    public Rigidbody2D rb;
    public bool dj_enabled;
    public float player_weight;
    public float jump_weight;

    bool grounded = false;
    bool second_jump;

    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (grounded || second_jump)) {
            // Force still movement so the 2nd jump will be constant
            rb.gravityScale = jump_weight;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jump_height));

            // Set second jump
            second_jump = grounded;

            grounded = false;
        }

        // Start falling down when key is released
        if (Input.GetKeyUp(KeyCode.UpArrow) && !grounded)
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(0, 0);

        if (rb.position.y < -10) {
            // Temp quit script
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        grounded = true;
        second_jump = dj_enabled;
        rb.gravityScale = player_weight;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D other = collision.attachedRigidbody;
        Destroy(other.gameObject);
        Destroy(other);
        GameManager.instance.coin_counter++;
    }
}
