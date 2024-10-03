using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFallState : State
{
    private Player player;
    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Fall");
        player.rigidBody.gravityScale = player.gravityScaler;
    }

    public override void OnExit()
    {
        player.rigidBody.gravityScale = 1.2f;
    }

    public override State StateUpdate()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            return player.jumpAttack;
        }

        if (player.isGrounded)
        {
            {
                return player.idle;
            }
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
        // gör så att spelaren inte kan falla snabbare än terminalVelocity
        player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, Mathf.Clamp(player.rigidBody.velocity.y, -player.terminalVelocity, player.terminalVelocity));


        return null;
    }

    public override State StateLateUpdate()
    {
        return null;
    }
}
