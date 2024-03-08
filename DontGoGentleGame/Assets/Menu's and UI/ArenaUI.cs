using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaUI : MonoBehaviour
{
    private float score = 0;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying score

    public GameObject gameOver;
    public PlayerStats playerStats;

    void Start()
    {
        // Subscribe to the OnEnemyDeath event
        Enemy.OnEnemyDeath += UpdateScore;
        score = 0;
        UpdateScore(score); // Update the score text to display 0

        playerStats = FindObjectOfType<PlayerStats>();
    }

    void FixedUpdate()
    {
        if(!playerStats.isAlive)
        {
            gameOver.SetActive(true);
        }
    }
    void UpdateScore(float points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    // Unsubscribe from the OnEnemyDeath event when this object is destroyed
    private void OnDestroy()
    {
        Enemy.OnEnemyDeath -= UpdateScore;
    }

    public void ReloadScene()
    {
        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene by loading it again with its index
        SceneManager.LoadScene(currentSceneIndex);
    }
}
