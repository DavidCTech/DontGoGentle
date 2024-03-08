using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHostile : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    public float speed = 3f;
    public bool isMovingLeft = false;
    public Vector2 movementDirection = Vector2.right; // Initial movement direction

    public GameObject player;
    public float chaseDistance;

    private Vector2 lastPosition; // Store the position in the previous frame

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentSpeed = Mathf.Abs((transform.position - (Vector3)lastPosition).x) / Time.fixedDeltaTime;
        anim.SetFloat("XVelocity", currentSpeed);

        lastPosition = (Vector2)transform.position;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 directionToPlayer = player.transform.position - transform.position;

        if (distance < chaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            // Face the player
            if (directionToPlayer.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            // Move in the specified direction
            transform.Translate(movementDirection * speed * Time.deltaTime);
            // Face the direction of movement
            if (movementDirection.x < 0.1f)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                isMovingLeft = !isMovingLeft; // Toggle movement direction
                movementDirection = isMovingLeft ? Vector2.left : Vector2.right; // Set movement direction based on the toggle 
            }
        }
    }

}
