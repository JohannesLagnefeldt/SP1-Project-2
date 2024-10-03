using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : State
{
    private Enemy enemy;

    [SerializeField] private AudioSource attackSound;

    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetTrigger("Attack");
        attackSound.Play();
    }

    public override void OnExit()
    {
        attackSound.Stop();
    }

    public override State StateFixedUpdate()
    {
        enemy.rigid_body.velocity = Vector2.zero;
        
        return null;
    }

    public override State StateLateUpdate()
    {
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            return enemy.patrol;
        }
        return null;
    }

    public override State StateUpdate()
    {
        
        return null;
    }

}
