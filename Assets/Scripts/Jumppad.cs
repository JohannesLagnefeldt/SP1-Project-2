using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{

    [SerializeField] private float jump_force;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D player_rigid_body = collision.GetComponent<Rigidbody2D>();
            player_rigid_body.velocity = new Vector2(player_rigid_body.velocity.x, 0);
            player_rigid_body.AddForce(new Vector2(0, jump_force));
            GetComponent<Animator>().SetTrigger("Jump");
        }
    }
}
