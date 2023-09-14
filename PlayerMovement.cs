using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCol;
    
    private float x = 0f;
    [SerializeField]private float speed = 7f;
    [SerializeField]private float jump = 14f;

    [SerializeField] private LayerMask groundJump;

    [SerializeField] private AudioSource jumpSound;
    
    private enum MovementStatus
    {
        idle,
        running,
        jumping,
        falling
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * x, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(0,jump);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementStatus status;
        if (x > 0f)
        {
            status = MovementStatus.running;
            sprite.flipX = false;
        }
        else if (x < 0f)
        {
            status = MovementStatus.running;
            sprite.flipX = true;
        }
        else
        {
            status = MovementStatus.idle;
        }

        if (rb.velocity.y > .1f)
        {
            status = MovementStatus.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            status = MovementStatus.falling;
        }
        
        animator.SetInteger("status", (int)status);
    }

    private bool isGrounded()
    {
       return  Physics2D.BoxCast(boxCol.bounds.center,
                boxCol.bounds.size,
                0f,
                Vector2.down,
                .1f,
                groundJump);
    }
}
