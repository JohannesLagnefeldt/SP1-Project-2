using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum facing {left = -1, right = 1}

    [SerializeField] public float move_speed;
    [SerializeField] private float sensDistance = 20f;
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private LayerMask sensLayerMask;
    [SerializeField] private GameObject death_particles;
    [SerializeField] private GameObject sensRayOrigin;

    public Rigidbody2D rigid_body;
    public SpriteRenderer sprite;
    public StateMachineController stateMachine;
    public Animator animator;
    public facing direction = facing.left;
    public RaycastHit2D sensLeft, sensRight;
    public State patrol;
    public State takeHit;
    public State die;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        sensLeft = Physics2D.Raycast(sensRayOrigin.transform.position, Vector2.left, sensDistance, sensLayerMask);
        sensRight = Physics2D.Raycast(sensRayOrigin.transform.position, Vector2.right, sensDistance, sensLayerMask);
        //print(sensLeft.collider + "-" + sensRight.collider);
    }



    public void Damage(int amount, float knockback = 2f)
    {
        rigid_body.velocity = new Vector2(knockback, 0);
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            stateMachine.ChangeState(die);
        }
        else
        {
            stateMachine.ChangeState(takeHit);
        }
        
    }
}
