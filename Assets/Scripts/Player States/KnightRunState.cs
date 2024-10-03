using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRunState : State
{
    private Player player;

    public override void OnEnter()
    {
        player = GetComponent<Player>();
        player.animator.SetTrigger("Run");
        player.rigidBody.velocity = new Vector2(player.rigidBody.velocity.x, 0);
        player.audioPlayer.PlayAudio("Run");
    }

    public override void OnExit()
    {
        player.audioPlayer.StopAudio();
    }

    public override State StateUpdate()
    {
        if (!(Mathf.Abs(player.horizontalInput) > 0))
        {
            return player.idle;
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
        float targetSpeed = player.horizontalInput * player.maxMoveSpeed;
        float speedDifference = player.rigidBody.velocity.x - targetSpeed;
        float realSpeed = speedDifference * player.acceleration;
        float decceleration = player.rigidBody.velocity.x * player.groundRecistance;
        player.rigidBody.AddForce((realSpeed + decceleration) * Vector2.left, ForceMode2D.Force);
        HandleSpriteFacing();
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

    private void HandleSpriteFacing() // true for left and false for right
    {
        if(player.horizontalInput < 0)
        {
            player.sprite.flipX = true;
            player.hitbox.transform.localPosition = new Vector3(-1.8f, 1.2f);
        }
        if(player.horizontalInput > 0)
        {
            player.sprite.flipX = false;
            player.hitbox.transform.localPosition = new Vector3(1.8f, 1.2f);
        }
    }

}
