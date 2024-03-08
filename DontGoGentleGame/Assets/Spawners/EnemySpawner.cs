using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public PlayerStats playerStats;

    public float spawnTimer = 1.0f;
    private bool isSpawning = false;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats component not found in the scene!");
        }

        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // Ensure we only spawn enemies if the player is alive
        while (playerStats != null && playerStats.isAlive)
        {
            // Check if we are currently spawning
            if (!isSpawning)
            {
                isSpawning = true;

                // Randomly select an index from the enemies array
                int randomIndex = Random.Range(0, enemies.Length);

                // Get the enemy prefab at the randomly selected index
                GameObject enemyToSpawn = enemies[randomIndex];

                // Spawn the enemy at the spawner's position and rotation
                Instantiate(enemyToSpawn, transform.position, transform.rotation);

                // Wait for the specified spawn timer duration
                yield return new WaitForSeconds(spawnTimer);

                isSpawning = false;
            }
            else
            {
                // Wait for a short duration before checking again
                yield return null;
            }
        }
    }
}
