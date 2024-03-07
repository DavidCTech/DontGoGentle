using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;

    Vector2 Movement;
    private Rigidbody2D rb;

    public float speed = 8f;
    public float jumpStrength = 8f;

    //public bool isGrounded;
    public int doubleJump = 2;



    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        /*rb.velocity = new Vector2(Movement.x * speed, rb.velocity.y);
        // Get the absolute value of horizontal velocity*/
        Vector2 velocity = rb.velocity;
        //velocity.x = Mathf.Abs(Movement.x) * speed * Mathf.Sign(Movement.x);
        velocity.x = Movement.x * speed;
        rb.velocity = velocity;
        
        float currentSpeed = Mathf.Abs(rb.velocity.x);
        anim.SetFloat("XVelocity", currentSpeed);
        
        float yVelocity = rb.velocity.y;
        anim.SetFloat("YVelocity", yVelocity);

        if (Movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
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
            anim.SetTrigger("Jumping");
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
            anim.SetBool("Grounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Update grounded status when leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
            anim.SetBool("Grounded", false);
        }
    }





}

