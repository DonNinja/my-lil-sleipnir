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
    float gravity;
    float ground_speed;
    KeyCode jump = KeyCode.UpArrow;

    private void Awake() {
        instance = this;
        init_time = Time.time;
        gravity = Physics2D.gravity.y * rb.gravityScale;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(jump) && (IsGrounded() || second_jump)) {
            // Force still movement so the 2nd jump will be constant
            rb.velocity = Vector2.up * jump_height;

            // Set second jump
            second_jump = IsGrounded() && dj_enabled;

            jump_sound.Play();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (!IsGrounded()) {
                rb.velocity += Vector2.up * gravity * (forced_down_weight - 1) * Time.deltaTime;
            }
            else {
                // Potential ducking thing?
            }
        }

        // Start falling down when key is released
        if (!IsGrounded()) {
            // Keeping this if we need it in the future
            //if (rb.velocity.y < 0)
            //    rb.velocity += Vector2.up * gravity * (player_weight - 1) * Time.deltaTime;
            //else 
            if (!Input.GetKey(jump))
                rb.velocity += Vector2.up * gravity * (rb.mass) * Time.deltaTime;
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
        if (other)
            coin_get_sound.Play();
    }

    private bool IsGrounded() {
        Vector2 ray_1 = center_collider.bounds.center - center_collider.bounds.extents;
        Vector2 ray_2 = center_collider.bounds.center + center_collider.bounds.extents;
        ray_2.y -= center_collider.bounds.extents.y * 2;
        float collider_offset = extra_height;
        //center_collider.bounds.extents.y +

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
