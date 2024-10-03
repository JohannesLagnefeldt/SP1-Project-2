using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChaseState : State
{
    private Enemy enemy;

    public float chaseTime = 5;
    public float aggresivenes = 1;
    public State slashAttack;
    public State throwAttck;

    private float chaseT;
    private float attackT;
    private float distanceToPlayer = 0; 
    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetTrigger("Walk");
        CheckFacing();
        chaseT = chaseTime;
    }

    public override void OnExit()
    {

    }

    public override State StateFixedUpdate()
    {
        enemy.rigid_body.velocity = new Vector2(enemy.move_speed * Time.deltaTime * (float)enemy.direction, enemy.rigid_body.velocity.y);

        return null;
    }

    public override State StateLateUpdate()
    {
        CheckFacing();

        return null;
    }

    public override State StateUpdate()
    {
        if (CheckForPlayer(enemy.sensLeft))
        {
            if(enemy.direction != Enemy.facing.left)
            {
                TurnAround();
            }
            chaseT = chaseTime;
            distanceToPlayer = enemy.sensLeft.distance;
        }
        else if (CheckForPlayer(enemy.sensRight))
        {
            if (enemy.direction != Enemy.facing.right)
            {
                TurnAround();
            }
            chaseT = chaseTime;
            distanceToPlayer = enemy.sensRight.distance;
        }
        else
        {
            chaseT -= Time.deltaTime;
            distanceToPlayer = 0;
        }

        if(chaseT < 0)
        {
            return enemy.patrol;
        }

        if(distanceToPlayer > 0)
        {
            float rand = Random.Range(0f, 100f);
            if (rand < (attackT / 100))
            {
                attackT = 0;
                if (distanceToPlayer <= 5)
                {
                    return slashAttack;
                }
                else
                {
                    print("Trow");
                } 
            }
            else
            {
                attackT += aggresivenes * Time.deltaTime;
            }
        }

        return null;
    }

    private void CheckDistanceOfObsticles(RaycastHit2D sens)
    {
        if ((!sens.collider.CompareTag("Player")) && sens.distance < 1)
        {
            TurnAround();
        }

    }

    private bool CheckForPlayer(RaycastHit2D sens)
    {
        return (sens && sens.collider.CompareTag("Player"));
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
        if (enemy.direction == Enemy.facing.left)
        {
            enemy.direction = Enemy.facing.right;
        }
        else if (enemy.direction == Enemy.facing.right)
        {
            enemy.direction = Enemy.facing.left;
        }

    }

}
