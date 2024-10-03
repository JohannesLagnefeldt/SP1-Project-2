using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightJumpState : State
{
    private Player player;

    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Jump");
        player.rigidBody.AddForce( new Vector2(0, player.jumpForce), ForceMode2D.Impulse);
        player.isGrounded = false; // lite klödigt sätt att garantera att isGrounded är false för första framen av hopet även om collidern är kvar på marken.
        player.audioPlayer.PlayAudio("Jump");
    }

    public override void OnExit()
    {

    }

    public override State StateUpdate()
    {

        if (Input.GetButtonUp("Jump"))
        {
            player.rigidBody.gravityScale = player.gravityScaler;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            return player.jumpAttack;
        }

        if (player.isGrounded)
        {
            player.rigidBody.gravityScale = 1;
            return player.idle;
        }
        else if(player.rigidBody.velocity.y < 0f)
        {
            return player.fall;
        }

        return null;
    }

    public override State StateFixedUpdate()
    {
        float targetSpeed = player.horizontalInput * player.maxAirSpeed;
        float speedDifference = player.rigidBody.velocity.x - targetSpeed;
        float realSpeed = speedDifference * player.airAcceleration;
        float decceleration = player.rigidBody.velocity.x * player.airRecistance;
        player.rigidBody.AddForce((realSpeed + decceleration) * Vector2.left, ForceMode2D.Force);

        return null;
    }

    public override State StateLateUpdate()
    {
        return null;
    }

}
