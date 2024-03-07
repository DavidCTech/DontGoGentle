using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float Health = 3f;
    public float MaxHealth = 3f;

    public int Defense = 3;
    public int MaxDefense = 3;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
