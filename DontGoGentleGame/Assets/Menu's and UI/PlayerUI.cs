using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour
{

    public PlayerStats playerStats;
    public TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI component for displaying health


    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            playerStats = playerObject.GetComponent<PlayerStats>();
        }
        else
        {
            Debug.LogError("PlayerStats component not found.");
        }
        UpdateHealth();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        // Check if both playerStats and healthText are not null before updating
        if (playerStats != null && healthText != null)
        {
            // Update the health text with the player's current health
            healthText.text = "Health: " + playerStats.Health.ToString();
        }
    }
}
