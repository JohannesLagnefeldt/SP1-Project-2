using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSlashState : State
{
    private Enemy enemy;
    private int attack;
    [SerializeField] private AudioSource attackSound;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private State chase;
    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetTrigger("Attack 1");
        attack = 1;
        attackSound.Play();
    }

    public override void OnExit()
    {

    }

    public override State StateFixedUpdate()
    {
        enemy.rigid_body.velocity = new Vector2(forwardSpeed * Time.deltaTime * (float)enemy.direction, enemy.rigid_body.velocity.y);

        return null;
    }

    public override State StateLateUpdate()
    {
        
        return null;
    }

    public override State StateUpdate()
    {
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            float random = Random.Range(0, 1f);
            switch (attack)
            {
                case 1:
                    if(random < 0.66f)
                    {
                        enemy.animator.SetTrigger("Attack 2");
                        attack = 2;
                        break;
                    }
                    else
                    {
                        return chase;
                    } 
                case 2:
                    if (random < 0.33f)
                    {
                        enemy.animator.SetTrigger("Attack 3");
                        attack = 3;
                        break;
                    }
                    else
                    {
                        return chase;
                    }
                case 3:
                    return chase;
            }
        }
        return null;
    }

}
