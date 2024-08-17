using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public Transform groundCheckL;
    public Transform groundCheckR;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    public Vector2 checkpoint;
    public int health = 3;

    private Rigidbody2D rb;
    private bool isGrounded;
    public MouseScrollScale mouseScrollScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "checkpoint")
        {
            checkpoint = collision.transform.position;
        }
    }
    public void returnplayertocheckpoint()
    {
        transform.position=checkpoint;
        health--;
        mouseScrollScale.canResize = true;
    }
    void Update()
    {
        // Move left and right
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if(Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer)||
            Physics2D.OverlapCircle(groundCheckL.position, checkRadius, groundLayer)||
            Physics2D.OverlapCircle(groundCheckR.position, checkRadius, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
