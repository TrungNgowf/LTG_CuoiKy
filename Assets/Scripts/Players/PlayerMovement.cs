using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private Animator anim;
    public PlayerStats stats;
    private bool isGrounded;
    private bool doubleJump;
    private HuntressAttack playerAttack;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<HuntressAttack>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * stats.speedRun, body.velocity.y);

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector2.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-1, 1);
        anim.SetBool("IsRunning", horizontalInput != 0);

        if (isGrounded && !Input.GetKeyDown(KeyCode.W))
        {
            doubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded || doubleJump)
            {
                Jump();
                doubleJump = !doubleJump;
            }
        }
        anim.SetBool("IsGrounded", isGrounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, stats.jumpForce);
        anim.SetTrigger("Jump");
        isGrounded = false;
        playerAttack.isAtk = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
