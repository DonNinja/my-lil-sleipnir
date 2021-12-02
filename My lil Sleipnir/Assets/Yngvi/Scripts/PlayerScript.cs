using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public float player_speed;
    public float max_speed;
    public float jump_height;
    public float player_weight;
    public float jump_weight;
    public float extra_height;
    public Rigidbody2D rb;
    public BoxCollider2D center_collider;
    public bool dj_enabled;
    public LayerMask ground;

    bool second_jump;
    float init_time;

    private void Awake() {
        instance = this;
        init_time = Time.time;
    }

    // Update is called once per frame
    void Update() {
        IsGrounded();
        if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGrounded() || second_jump)) {
            // Force still movement so the 2nd jump will be constant
            rb.gravityScale = jump_weight;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jump_height));

            // Set second jump
            second_jump = IsGrounded();
        }

        // Start falling down when key is released
        if (Input.GetKeyUp(KeyCode.UpArrow) && !IsGrounded())
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(0, 0);

        if (rb.position.y < -50) {
            // Temp quit script
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate() {
        if (Time.time - init_time > 4) {
            if (player_speed < max_speed) {
                player_speed += 0.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        second_jump = dj_enabled;
        rb.gravityScale = player_weight;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D other = collision.attachedRigidbody;
        if (other) {
            Destroy(other.gameObject);
            Destroy(other);
            GameManager.instance.coin_counter++;
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycast_hit = Physics2D.Raycast(center_collider.bounds.center, Vector2.down, center_collider.bounds.extents.y + extra_height, ground);

        // Debugging
        Color ray_colour;
        if (raycast_hit.collider != null)
            ray_colour = Color.green;
        else
            ray_colour = Color.red;

        Debug.DrawRay(center_collider.bounds.center, Vector2.down * (center_collider.bounds.extents.y + extra_height), ray_colour);

        return raycast_hit.collider != null;
    }
}
