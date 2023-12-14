using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Animator animator;
    private Ray2D ray;
    private bool jump = false;
    private bool isGrounded;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                animator.SetBool("isJumping", !isGrounded);
                jump = true;
            }
        }
    }
    private void FixedUpdate()
    {
        //ray = new Ray2D();
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayer);
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.001)
        {
            spriteRender.flipX = true;
        }
        else if(horizontalInput < -0.001)
        {
            spriteRender.flipX = false;
        }
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("isJumping", !isGrounded);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(ray);
    }
}
