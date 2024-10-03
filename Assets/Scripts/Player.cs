using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float maxMoveSpeed;
    [SerializeField] public float acceleration;
    [SerializeField] public float groundRecistance;
    [SerializeField] public float maxAirSpeed;
    [SerializeField] public float airAcceleration;
    [SerializeField] public float airRecistance;
    [SerializeField] public float jumpForce;
    [SerializeField] public float gravityScaler;
    [SerializeField] public float terminalVelocity;
    [SerializeField] public int maxHealth;


    public State idle;
    public State run;
    public State takeHit;
    public State jump;
    public State fall;
    public State attack;
    public State jumpAttack;
    public Animator animator;
    public StateMachineController stateMachine;
    public Rigidbody2D rigidBody;
    public SpriteRenderer sprite;
    public GameObject hitbox;
    public PlayerAudio audioPlayer;

    public float horizontalInput;
    public bool isGrounded;
    public int currentHealth;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineController>();
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    public void Damage(int amount, float knockback = 0)
    {
        currentHealth -= amount;
        rigidBody.velocity = new Vector2(knockback, 1);
        if(currentHealth <= 0)
        {
            print("Die");
        }
        stateMachine.ChangeState(takeHit);
    }

}
