using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightJumpAttackState : State
{
    private Player player;
    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Jump Attack");
        player.audioPlayer.PlayAudio("Attack");
    }

    public override void OnExit()
    {
        
    }

    public override State StateFixedUpdate()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (player.isGrounded)
            {
                return player.idle;
            }
            else
            {
                return player.fall;
            }    
        }
        return null;
    }

    public override State StateLateUpdate()
    {
        float decceleration = player.rigidBody.velocity.x * player.airRecistance;
        player.rigidBody.AddForce((decceleration) * Vector2.left, ForceMode2D.Force);

        return null;
    }

    public override State StateUpdate()
    {
        return null;
    }

}
