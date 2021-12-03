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
    public AudioSource coin_get_sound;
    public AudioSource jump_sound;

    bool second_jump;
    float init_time;

    private void Awake() {
        instance = this;
        init_time = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGrounded() || second_jump)) {
            // Force still movement so the 2nd jump will be constant
            rb.gravityScale = jump_weight;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jump_height));

            // Set second jump
            second_jump = IsGrounded() && dj_enabled;

            jump_sound.Play();
        }

        // Start falling down when key is released
        if (Input.GetKeyUp(KeyCode.UpArrow) && !IsGrounded())
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(0, 0);

        if (rb.position.y < -50) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

            GameManager.instance.hunger -= Random.Range(0, 2);
            GameManager.instance.hygiene -= Random.Range(0, 5);
            GameManager.instance.comfort -= Random.Range(0, 3);

            SceneManager.LoadSceneAsync("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        second_jump = dj_enabled;
        rb.gravityScale = player_weight;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D other = collision.attachedRigidbody;
        if (other) {
            coin_get_sound.Play();
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
