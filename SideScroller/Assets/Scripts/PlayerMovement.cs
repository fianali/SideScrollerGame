using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 250f;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float radius;

    private Animator animator;
    private Rigidbody2D rb;
    private float direction;
    private bool facingRight = true;
    private bool isJumping = false;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundObjects);
        Move();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        Flip();
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));  
        }

        isJumping = false;
        animator.SetBool("isJumping", isJumping);

    }

//flip character based on direction
    private void Flip()
    {
        //if character is facing left
        if (direction > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (direction < 0 && facingRight)
        {
            FlipCharacter();
        }
    }
    void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    private void GetInputs()
    {
        direction = Input.GetAxis("Horizontal");
        animator.SetFloat("direction", direction);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
    }

}
