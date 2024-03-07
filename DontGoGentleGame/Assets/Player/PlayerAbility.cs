using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAbility : MonoBehaviour
{
    public GameObject hitBox1;
    public GameObject hitBox2;
    public GameObject hitBox3;

    private Animator anim;

    public int attackState = 0;
    private bool canAttack = true;
    public float attackCooldown = 0.3f; // Adjust cooldown time as needed
    //private bool clickDelay = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnAttack()
    {
        if (canAttack)
        {
            attackState++;
            if (attackState == 1)
            {
                anim.SetTrigger("Attack1");
            }
            else if (attackState == 2)
            {
                anim.SetTrigger("Attack2");
            }
            else if (attackState == 3)
            {
                anim.SetTrigger("Attack3");
            }

            if (attackState == 3)
            {
                StartCoroutine(AttackCooldown());
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        attackState = 0;
        canAttack = true;
 
    }
}
