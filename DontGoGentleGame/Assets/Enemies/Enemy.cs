using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum EnemyType
    {
        Wizard,
        Goblin,
        Mushroom,
        Skeleton,
        FlyingEye
    }

    public struct EnemyStats
    {
        public float Health;
        public float moveSpeed;
        public float contactDamage;
    }

    private static readonly EnemyStats[] enemyTypeStats = new EnemyStats[]
    {
        // Wizard Enemy Stats
        new EnemyStats
        {
            Health = 15f,
            moveSpeed = 2f,
            contactDamage = 1f
        },

        // Goblin Enemy Stats
        new EnemyStats
        {
            Health = 10f,
            moveSpeed = 7f,
            contactDamage = 2f
        },

        // Mushroom Enemy Stats
        new EnemyStats
        {
            Health = 5f,
            moveSpeed = 1.5f,
            contactDamage = 1f
        },

        // Skeleton Enemy Stats
        new EnemyStats
        {
            Health = 25f,
            moveSpeed = 1.5f,
            contactDamage = 3f
        },

        // FlyingEye Enemy Stats
        new EnemyStats
        {
            Health = 5f,
            moveSpeed = 3f,
            contactDamage = 1f
        }
    };

    public EnemyType enemyType;
    private EnemyStats currentStats;

    public bool isHit = false; // Flag to track if the enemy is inside the trigger


    void Start()
    {
        // Set stats based on the enemy type
        currentStats = enemyTypeStats[(int)enemyType];
    }

    // Example method to apply damage to the enemy
    public void TakeDamage(float damage)
    {
        currentStats.Health -= damage;
        if (currentStats.Health <= 0)
        {
            Die();
        }
    }

    // Example method to handle enemy death
    private void Die()
    {
        // Perform death logic here
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the tag "Sword"
        if (other.CompareTag("Sword") && !isHit)
        {
            TakeDamage(10.0f);
            isHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exited the trigger has the tag "Sword" and if the enemy was previously inside the trigger
        if (other.CompareTag("Sword") && isHit)
        {
            isHit = false; // Reset the flag when the enemy exits the trigger
        }
    }

}
