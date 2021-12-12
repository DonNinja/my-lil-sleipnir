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
    [SerializeField] float init_max_speed;
    [SerializeField] float jump_height;
    [SerializeField] float forced_down_weight;
    [SerializeField] float extra_height;
    [SerializeField] float grounded_offset;
    [SerializeField] float speed_add;
    [SerializeField] float brake_speed;
    [SerializeField] float test_val;

    bool second_jump;
    float gravity;
    bool grounded;
    float max_speed;

    float hunger_weight = .75f;
    float hygiene_weight = .05f;
    float comfort_weight = .20f;

    KeyCode jump = KeyCode.UpArrow;
    KeyCode faster = KeyCode.RightArrow;
    KeyCode slower = KeyCode.LeftArrow;

    private void Awake() {
        instance = this;
        gravity = Physics2D.gravity.y * rb.gravityScale;
        if (GameManager.instance) {
            max_speed = init_max_speed + (GameManager.instance.hunger * hunger_weight + GameManager.instance.hygiene * hygiene_weight + GameManager.instance.comfort * comfort_weight);
        }
        else {
            max_speed = init_max_speed + (test_val * hunger_weight + test_val * hygiene_weight + test_val * comfort_weight);
        }
        player_speed = (min_speed + max_speed) / 2;
    }

    // Update is called once per frame
    void Update() {
        float curr_speed = player_speed / ((min_speed + max_speed) / 2);
        grounded = IsGrounded();

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Y_mov", rb.velocity.y);

        if (Input.GetKeyDown(jump) && (grounded || second_jump)) {
            jump_sound.Play();
            // Force still movement so the 2nd jump will be constant
            rb.velocity = Vector2.up * jump_height;

            // Set second jump
            second_jump = grounded && GameManager.instance.is_active_doublejump;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && GameManager.instance.is_active_groundpound)
            if (!grounded)
                rb.velocity += Vector2.up * gravity * (forced_down_weight - 1) * Time.deltaTime;

        // Start falling down when key is released
        if (!grounded) {
            anim.speed = 1;

            if (!Input.GetKey(jump))
                rb.velocity += Vector2.up * gravity * rb.mass * Time.deltaTime;
        }
        else {
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

            anim.speed = curr_speed;
            second_jump = GameManager.instance.is_active_doublejump;
        }

        if (rb.position.y < -50) {
#if UNITY_EDITOR
            //UnityEditor.EditorApplication.isPlaying = false;
            UnityEditor.EditorApplication.isPaused = true;
#endif

            GameManager.instance.EndGame();
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
