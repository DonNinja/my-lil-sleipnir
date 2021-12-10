using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public float player_speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D center_collider;
    [SerializeField] LayerMask ground;
    public AudioSource coin_get_sound;
    [SerializeField] AudioSource jump_sound;
    [SerializeField] Animator anim;
    [SerializeField] float min_speed;
    [SerializeField] float max_speed;
    [SerializeField] float jump_height;
    [SerializeField] float forced_down_weight;
    [SerializeField] float extra_height;
    [SerializeField] float grounded_offset;
    [SerializeField] float speed_add;
    [SerializeField] float brake_speed;
    [SerializeField] bool dj_enabled;

    bool second_jump;
    float gravity;
    bool grounded;

    KeyCode jump = KeyCode.UpArrow;
    KeyCode faster = KeyCode.RightArrow;
    KeyCode slower = KeyCode.LeftArrow;

    private void Awake() {
        instance = this;
        gravity = Physics2D.gravity.y * rb.gravityScale;
    }

    // Update is called once per frame
    void Update() {
        float curr_speed = player_speed / ((min_speed + max_speed) / 2);
        grounded = IsGrounded();
        if (Input.GetKeyDown(jump) && (grounded || second_jump)) {
            // Force still movement so the 2nd jump will be constant
            rb.velocity = Vector2.up * jump_height;

            // Set second jump
            second_jump = grounded && dj_enabled;

            jump_sound.Play();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (!grounded) {
                rb.velocity += Vector2.up * gravity * (forced_down_weight - 1) * Time.deltaTime;
            }
            else {
                // Potential ducking thing?
            }
        }

        if (Input.GetKey(faster)) {
            if (player_speed < max_speed) {
                // Increase speed
                player_speed += speed_add;
            }
        }
        else if (Input.GetKey(slower)) {
            if (player_speed > min_speed) {
                // Decrease speed
                player_speed -= brake_speed;
            }
        }

        // Start falling down when key is released
        if (!grounded) {
            anim.speed = curr_speed * 0.2f;

            if (!Input.GetKey(jump))
                rb.velocity += Vector2.up * gravity * rb.mass * Time.deltaTime;
        }
        else {
            anim.speed = curr_speed;
            second_jump = dj_enabled;
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

    private bool IsGrounded() {
        Vector2 ray_1 = center_collider.bounds.center;
        ray_1.x -= (center_collider.bounds.extents.x + grounded_offset);
        Vector2 ray_2 = center_collider.bounds.center;
        ray_2.x += center_collider.bounds.extents.x;
        float collider_offset = center_collider.bounds.extents.y + extra_height;

        RaycastHit2D raycast_hit_1 = Physics2D.Raycast(ray_1, Vector2.down, collider_offset, ground);
        RaycastHit2D raycast_hit_2 = Physics2D.Raycast(ray_2, Vector2.down, collider_offset, ground);

        bool on_ground = raycast_hit_1.collider != null || raycast_hit_2.collider != null;

        // This creates a line for debugging
        Color ray_colour = on_ground ? Color.green : Color.red;
        Debug.DrawRay(ray_1, Vector2.down * collider_offset, ray_colour);
        Debug.DrawRay(ray_2, Vector2.down * collider_offset, ray_colour);

        return on_ground;
    }
}
