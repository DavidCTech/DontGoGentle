using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctions : MonoBehaviour
{

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
