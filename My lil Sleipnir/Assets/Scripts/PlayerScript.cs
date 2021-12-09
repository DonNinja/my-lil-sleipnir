using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public GameObject player;
    public float player_speed;
    [SerializeField] float max_speed;
    [SerializeField] float jump_height;
    [SerializeField] float player_weight;
    [SerializeField] float low_jump_weight;
    [SerializeField] float forced_down_weight;
    [SerializeField] float extra_height;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D center_collider;
    [SerializeField] bool dj_enabled;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jump_sound;
    public AudioSource coin_get_sound;
    [SerializeField] float grounded_offset;

    bool second_jump;
    float init_time;
    float gravity;
    bool grounded;
    KeyCode jump = KeyCode.UpArrow;

    private void Awake() {
        instance = this;
        init_time = Time.time;
        gravity = Physics2D.gravity.y * rb.gravityScale;
    }

    // Update is called once per frame
    void Update() {
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

        // Start falling down when key is released
        if (!grounded) {
            // Keeping this if we need it in the future
            //if (rb.velocity.y < 0)
            //    rb.velocity += Vector2.up * gravity * (player_weight - 1) * Time.deltaTime;
            //else 
            if (!Input.GetKey(jump))
                rb.velocity += Vector2.up * gravity * (rb.mass) * Time.deltaTime;
        }
        else {
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
