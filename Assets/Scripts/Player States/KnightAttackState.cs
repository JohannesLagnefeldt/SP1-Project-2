using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackState : State
{
    private Player player;
    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Attack");
        player.audioPlayer.PlayAudio("Attack");
    }

    public override void OnExit()
    {
        
    }

    public override State StateFixedUpdate()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            return player.idle;
        }
        return null;
    }

    public override State StateLateUpdate()
    {
        float targetSpeed = player.horizontalInput * (player.maxMoveSpeed / 10);
        float speedDifference = player.rigidBody.velocity.x - targetSpeed;
        float realSpeed = speedDifference * player.acceleration;
        float decceleration = player.rigidBody.velocity.x * player.groundRecistance;
        player.rigidBody.AddForce((realSpeed + decceleration) * Vector2.left, ForceMode2D.Force);
        if (player.rigidBody.velocity.y < -2)
        {
            return player.fall;
        }

        return null;
    }

    public override State StateUpdate()
    {
        return null;
    }

}
