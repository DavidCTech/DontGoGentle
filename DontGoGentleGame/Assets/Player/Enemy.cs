using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the tag "Sword"
        if (other.CompareTag("Sword"))
        {
            // If collided with the sword, destroy the object
            Destroy(gameObject);
        }
    }
}
