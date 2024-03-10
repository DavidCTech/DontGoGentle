using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAbility : MonoBehaviour
{
    private Animator anim;

    private int attackState = 0;
    private bool canAttack = true;
    public float attackCooldown = 0.3f; // Adjust cooldown time as needed
    //private bool clickDelay = false;

    private AudioSource audioSource;
    public AudioClip[] attackClips;


    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnAttack()
    {
        if (canAttack)
        {
            attackState++;
            if (attackState == 1)
            {
                anim.SetTrigger("Attack1");
                PlayAttackSound(0);
            }
            else if (attackState == 2)
            {
                anim.SetTrigger("Attack2");
                PlayAttackSound(1);
            }
            else if (attackState == 3)
            {
                anim.SetTrigger("Attack3");
                PlayAttackSound(2);
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

    void PlayAttackSound(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < attackClips.Length)
        {
            audioSource.clip = attackClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid clip index for attack sound.");
        }
    }
}
