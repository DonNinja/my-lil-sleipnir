using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    [Range(0, 30)]
    public float player_speed;
    public float max_speed;
    [Range(0, 20)]
    public float jump_height;
    [Range(0, 20)]
    public float player_weight;
    public float low_jump_weight;
    public float forced_down_weight;
    public float extra_height;
    public Rigidbody2D rb;
    public BoxCollider2D center_collider;
    public bool dj_enabled;
    public LayerMask ground;
    public AudioSource coin_get_sound;
    public AudioSource jump_sound;

    bool second_jump;
    float init_time;
    KeyCode jump = KeyCode.UpArrow;

    private void Awake() {
        instance = this;
        init_time = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(jump) && (IsGrounded() || second_jump)) {
            // Force still movement so the 2nd jump will be constant
            rb.velocity = new Vector2(0, 0);
            rb.velocity = Vector2.up * jump_height;

            // Set second jump
            second_jump = IsGrounded() && dj_enabled;

            jump_sound.Play();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (!IsGrounded()) {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (forced_down_weight - 1) * Time.deltaTime;
            }
            else {
                // Potential ducking thing?
            }
        }

        // Start falling down when key is released
        if (!IsGrounded()) {
            if (rb.velocity.y < 0)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (player_weight - 1) * Time.deltaTime;
            else if (!Input.GetKey(jump) && rb.velocity.y > 0)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (low_jump_weight - 1) * Time.deltaTime;
        }

        if (rb.position.y < -50) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

            GameManager.instance.hunger -= Random.Range(0f, 2f);
            GameManager.instance.hygiene -= Random.Range(0f, 5f);
            GameManager.instance.comfort -= Random.Range(0f, 3f);

            SceneManager.LoadSceneAsync("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        second_jump = dj_enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D other = collision.attachedRigidbody;
        if (other) {
            coin_get_sound.Play();
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
