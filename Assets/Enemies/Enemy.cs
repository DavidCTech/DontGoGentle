using System;
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
        public float pointWorth;
        public float contactDamage;
    }

    public static event Action<float> OnEnemyDeath;

    private static readonly EnemyStats[] enemyTypeStats = new EnemyStats[]
    {
        // Wizard Enemy Stats
        new EnemyStats
        {
            Health = 15f,
            pointWorth = 200f,
            contactDamage = 1f
        },

        // Goblin Enemy Stats
        new EnemyStats
        {
            Health = 10f,
            pointWorth = 100f,
            contactDamage = 2f
        },

        // Mushroom Enemy Stats
        new EnemyStats
        {
            Health = 5f,
            pointWorth = 50f,
            contactDamage = 1f
        },

        // Skeleton Enemy Stats
        new EnemyStats
        {
            Health = 25f,
            pointWorth = 250f,
            contactDamage = 3f
        },

        // FlyingEye Enemy Stats
        new EnemyStats
        {
            Health = 5f,
            pointWorth = 150f,
            contactDamage = 1f
        }
    };

    public EnemyType enemyType;
    public EnemyStats currentStats;

    public bool isHit = false; // Flag to track if the enemy is inside the trigger


    void Start()
    {
        // Set stats based on the enemy type
        currentStats = enemyTypeStats[(int)enemyType];
    }

    // Example method to apply damage to the enemy
    public void EnemyTakeDamage(float damage)
    {
        currentStats.Health -= damage;
        if (currentStats.Health <= 0)
        {
            Death();
        }
    }

    // Example method to handle enemy death
    public void Death()
    {
        // Perform death logic here
        Debug.Log("Enemy died!");
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath(currentStats.pointWorth);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the tag "Sword"
        if (other.CompareTag("Sword") && !isHit)
        {
            EnemyTakeDamage(10.0f);
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
