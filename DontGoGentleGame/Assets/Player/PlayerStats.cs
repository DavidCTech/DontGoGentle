using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Animator anim;

    public float Health = 10f;
    public float MaxHealth = 10f;

    public int Defense = 3;
    public int MaxDefense = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Health", Health);

        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is tagged as an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the contact damage from the enemy
            float contactDamage = collision.gameObject.GetComponent<Enemy>().currentStats.contactDamage;

            // Apply damage to the player
            TakeDamage(contactDamage);
        }
    }

    void TakeDamage(float damage)
    {
        Health -= damage;
        anim.SetFloat("Health", Health);


        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Implement player death logic here, e.g., respawn the player, game over screen, etc.
    }

}
