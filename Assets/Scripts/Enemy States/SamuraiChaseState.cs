using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiChaseState : State
{
    private enum attackDistance { NEAR = 1, FAR = -1}

    private Enemy enemy;
    private attackDistance currentAttack;

    [SerializeField] private Transform player;

    public float aggresivenes = 1;
    public State slashAttack;
    public State bowShoot;


    private float attackT = 0;
    private float distanceToPlayer = 0;
    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        TurnFacingPlayer();
        CheckFacing();
        FindNewTarget();

        if (currentAttack == attackDistance.FAR)
        {
            enemy.animator.SetTrigger("Walk Back");
        }
        else if (currentAttack == attackDistance.NEAR)
        {
            enemy.animator.SetTrigger("Walk");
        }
    }

    public override void OnExit()
    {

    }

    public override State StateFixedUpdate()
    {

        enemy.rigid_body.velocity = new Vector2(enemy.move_speed * Time.deltaTime * (float)enemy.direction * (float)currentAttack, enemy.rigid_body.velocity.y);

        

        if (enemy.sensLeft)
        {
            CheckDistanceOfObsticles(enemy.sensLeft);
        }
        if (enemy.sensRight)
        {
            CheckDistanceOfObsticles(enemy.sensRight);
        }

        return null;
    }

    public override State StateLateUpdate()
    {
        
        CheckFacing();

        return null;
    }

    public override State StateUpdate()
    {
        TurnFacingPlayer();

        float random = Random.Range(0f, 100f);
        if (random < (attackT / 100))
        {
            attackT = 0;
            return DoAttack();
        }
        else
        {
            attackT += aggresivenes * Time.deltaTime;
        }

        return null;
    }

    private State DoAttack()
    {
        float random = Random.Range(0, 1f);
        float attackWeight = Mathf.Abs(distanceToPlayer) / 14; // 28 är hur stor arenan är. attackWeight är avståndet till spelaren som procent av max avståndet.

        if(random > attackWeight)
        {
            return slashAttack;
        }
        else if(random < attackWeight)
        {
            return bowShoot;
        }
        return null;
    }

    private void CheckDistanceOfObsticles(RaycastHit2D sens)
    {
        if ((!sens.collider.CompareTag("Player")) && sens.distance < 1)
        {
            currentAttack = attackDistance.NEAR;
            enemy.animator.SetTrigger("Walk");
        }

    }

    private void TurnFacingPlayer()
    {
        distanceToPlayer = (player.position - transform.position).x;

        if(distanceToPlayer < 0)
        {
            enemy.direction = Enemy.facing.left;
        }

        else if (distanceToPlayer > 0)
        {
            enemy.direction = Enemy.facing.right;
        }
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

    private void FindNewTarget()
    {
        float random = Random.Range(0, 1f);
        if (random > 0.5)
        {
            currentAttack = attackDistance.FAR;
        }
        else
        {
            currentAttack = attackDistance.NEAR;
        }
    }
   
}