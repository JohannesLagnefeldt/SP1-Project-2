using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeHitState : State
{
    private Enemy enemy;

    [SerializeField] private State getOffMe;
    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        gameObject.layer = 9;
        enemy.animator.SetTrigger("Take Hit");
    }

    public override void OnExit()
    {
        gameObject.layer = 8;
        enemy.rigid_body.velocity = Vector2.zero;
    }

    public override State StateFixedUpdate()
    {
        return null;
    }

    public override State StateLateUpdate()
    {
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (getOffMe)
            {
                float random = Random.Range(0, 1f);
                if (random < 0.44)
                {
                    return getOffMe;
                }
            }
            return enemy.patrol;
        }
        return null;
    }

    public override State StateUpdate()
    {
        return null;
    }

}
