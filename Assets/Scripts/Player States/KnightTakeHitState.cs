using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightTakeHitState : State
{
    private Player player;
    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Take Damage");
        player.audioPlayer.PlayAudio("Jump");
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
        float decceleration = player.rigidBody.velocity.x * player.airRecistance;
        player.rigidBody.AddForce((decceleration) * Vector2.left, ForceMode2D.Force);

        return null;
    }

    public override State StateUpdate()
    {
        return null;
    }

}
