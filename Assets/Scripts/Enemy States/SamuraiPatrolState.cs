using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiPatrolState : State
{
    private Enemy enemy;
    [SerializeField] private State chase;

    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetTrigger("Idle");
        CheckFacing();
    }

    public override void OnExit()
    {

    }

    public override State StateFixedUpdate()
    {
        return CheckForPlayer();
    }

    public override State StateLateUpdate()
    {

        CheckFacing();
        return null;
    }

    public override State StateUpdate()
    {
        return null;
    }

    private State CheckForPlayer()
    {
        if (enemy.sensLeft && enemy.sensLeft.collider.CompareTag("Player"))
        {
            return chase;
            
        }
        if (enemy.sensRight && enemy.sensRight.collider.CompareTag("Player"))
        {
            return chase;
        }

        return null;
    }

    private void CheckFacing()
    {
        if (enemy.direction == Enemy.facing.left)
        {
            enemy.sprite.flipX = true;
        }
        else if (enemy.direction == Enemy.facing.right)
        {
            enemy.sprite.flipX = false;
        }
    }

}
