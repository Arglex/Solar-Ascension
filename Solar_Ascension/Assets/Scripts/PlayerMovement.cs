using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    private Ray ray;
    private bool isGrounded;

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        ray = new Ray(groundCheck.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, 0.2f, groundLayer);
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, 0f);
        rb.velocity = movement;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray);
    }
}
