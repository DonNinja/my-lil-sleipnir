using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jump_height;
    public Rigidbody2D rb;
    public bool dd_enabled = false;

    bool grounded;
    bool second_jump;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (grounded || second_jump))
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jump_height));
            if (!grounded)
                second_jump = false;
            grounded = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !grounded)
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
        second_jump = dd_enabled ? true : false;
    }
}
