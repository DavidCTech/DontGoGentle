using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 Movement;
    private Rigidbody2D rb;

    public float speed = 8f;
    public float jumpStrength = 8f;

    //public bool isGrounded;
    public int doubleJump = 2;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(Movement.x * speed, rb.velocity.y);
    }

    public void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (doubleJump > 0)
        {
            // Add upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            doubleJump--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
            doubleJump = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Update grounded status when leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
        }
    }





}

