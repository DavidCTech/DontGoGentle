using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Animator anim;

    public float currentHealth = 10f;
    public float MaxHealth = 10f;

    public int Defense = 3;
    public int MaxDefense = 3;


    public bool isAlive = true; // Flag to track player's alive/dead state

    private AudioSource audioSource;
    public AudioClip deathClip;
    public AudioClip[] hurtClips;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Health", currentHealth);
        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is alive before processing collision
        if (isAlive)
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
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetFloat("Health", currentHealth);

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth > 0)
        {
            // Play a random hurt sound
            if (hurtClips.Length > 0)
            {
                int randomIndex = Random.Range(0, hurtClips.Length);
                audioSource.PlayOneShot(hurtClips[randomIndex]);
            }
        }
        else
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        isAlive = false;
        anim.SetTrigger("Death");
        audioSource.PlayOneShot(deathClip);
        //anim.SetBool("Death", true);
        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.Confined; // Confine cursor to game window
        Cursor.visible = true;
    }

}
