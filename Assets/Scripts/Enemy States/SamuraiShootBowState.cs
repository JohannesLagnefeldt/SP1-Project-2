using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiShootBowState : State
{
    private Enemy enemy;

    [SerializeField] private State chase;
    [SerializeField] private float spawnOffset;
    [SerializeField] private AudioSource bowSound;


    [SerializeField] private GameObject arrow;
    public override void OnEnter()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetTrigger("Shoot");
        
    }

    public override void OnExit()
    {

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
            return chase;
        }
        return null;
    }

    public override State StateUpdate()
    {
        return null;
    }

    public void shoot()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, spawnOffset, 0);
        GameObject newArrow = Instantiate(arrow, spawnPosition, Quaternion.identity);
        newArrow.GetComponent<Arrow>().setDirection((float)enemy.direction);
        bowSound.Play();
    }

}
