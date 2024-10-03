using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : State
{
    private Player player;

    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Idle");
        player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, 0);
    }

    public override void OnExit()
    {

    }

    public override State StateUpdate()
    {
        
        if (Mathf.Abs(player.horizontalInput) > 0)
        {
            return player.run;
        }

        if (Input.GetButtonDown("Jump"))
        {
            return player.jump;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            return player.attack;
        }

        return null;
    }

    public override State StateFixedUpdate()
    {
        float decceleration = (player.rigidBody.velocity.x * player.groundRecistance);
        player.rigidBody.AddForce(decceleration * Vector2.left, ForceMode2D.Force);
        
        if (player.rigidBody.velocity.y < -2)
        {

            return player.fall;
        }
        return null;
    }

    public override State StateLateUpdate()
    {
        return null;
    }
}
