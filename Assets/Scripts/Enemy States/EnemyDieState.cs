using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : State
{
    private Enemy enemy;
    [SerializeField] private float timeToDespawn = 2;

    private float despawnT = 0;
    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        gameObject.layer = 9;
        enemy.animator.SetTrigger("Die");
        despawnT = timeToDespawn;
    }

    public override void OnExit()
    {

    }

    public override State StateFixedUpdate()
    {
        return null;
    }

    public override State StateLateUpdate()
    {
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            despawnT -= Time.deltaTime;
            enemy.rigid_body.velocity = Vector2.zero;
        }

        if (despawnT <= 0)
        {
            
            enemy.sprite.color -= new Color(0,0,0,1 * Time.deltaTime);

            if(enemy.sprite.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        return null;
    }

    public override State StateUpdate()
    {

        return null;
    }

}
