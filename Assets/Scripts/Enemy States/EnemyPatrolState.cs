using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : State
{
    private Enemy enemy;
    [SerializeField] private State chase;

    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetTrigger("Walk");
        CheckFacing();
    }

    public override void OnExit()
    {
        
    }

    public override State StateFixedUpdate()
    {
        enemy.rigid_body.velocity = new Vector2(enemy.move_speed * Time.deltaTime * (float)enemy.direction, enemy.rigid_body.velocity.y);

        if (enemy.direction == Enemy.facing.left && enemy.sensLeft)
        {
            CheckDistanceOfObsticles(enemy.sensLeft);
        }
        else if (enemy.direction == Enemy.facing.right && enemy.sensRight)
        {
            CheckDistanceOfObsticles(enemy.sensRight);
        }

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

    private void CheckDistanceOfObsticles(RaycastHit2D sens)
    {
        if((! sens.collider.CompareTag("Player")) && sens.distance < 1)
        {
            TurnAround();
        }
        
    }

    private State CheckForPlayer()
    {
        if(enemy.sensLeft && enemy.sensLeft.collider.CompareTag("Player"))
        {
            enemy.direction = Enemy.facing.left;
            return chase;
        }
        if (enemy.sensRight && enemy.sensRight.collider.CompareTag("Player"))
        {
            enemy.direction = Enemy.facing.right;
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

    private void TurnAround()
    {
        if(enemy.direction == Enemy.facing.left) 
        {
            enemy.direction = Enemy.facing.right;
        }
        else if (enemy.direction == Enemy.facing.right)
        {
            enemy.direction = Enemy.facing.left;
        }

    }

}
