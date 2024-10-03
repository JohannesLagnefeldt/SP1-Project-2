using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public enum facing
    {
        Left = -1,
        Right = 1
    }

    private float horizontal_input;
    private int current_health;
    private int points = 0;
    private bool is_grounded;
    private bool can_move;



    private Rigidbody2D rigid_body;
    private SpriteRenderer player_sprite;
    private CircleCollider2D foot_collider;
    private Animator animator;
    private AudioSource audio_player;
    

    [SerializeField] private Transform spawn_position;
    [SerializeField] private float move_speed = 500f;
    [SerializeField] private float jump_force = 120f;
    [SerializeField] private float air_control = 2;
    [SerializeField] private LayerMask grounded_layer_mask;
    [SerializeField] public int starting_health = 10;
    [SerializeField] private Camera cam;
    [SerializeField] private AudioClip damage_sound, score_sound;
    [SerializeField] private List<AudioClip> jump_sounds;

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        player_sprite = GetComponent<SpriteRenderer>();
        foot_collider = GetComponentInChildren<CircleCollider2D>();
        animator = GetComponent<Animator>();
        audio_player = GetComponent<AudioSource>();
        current_health = starting_health;

        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_input = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown("o")) //Kanpp för debugging
        {

        }

        
    }

    private void FixedUpdate()
    {

        if (!can_move)
        {
            return;
        }

        GroundCheck();
        float horizontal_speed = horizontal_input * move_speed * Time.deltaTime;
        HandlePlayerMovmentDirection(horizontal_input);
        if (is_grounded)
        {
            rigid_body.velocity = new Vector2(horizontal_speed, rigid_body.velocity.y);
        }
        else
        {
            rigid_body.velocity = Vector2.Lerp(rigid_body.velocity, new Vector2(horizontal_speed, rigid_body.velocity.y), air_control * Time.deltaTime);
        }
    }

    
    private void HandlePlayerMovmentDirection(float horizontal_direction)
    {

        if(horizontal_direction < 0)
        {
            player_sprite.flipX = true;
        }
        else if (horizontal_direction > 0)
        {
            player_sprite.flipX = false;
        }

        if (Mathf.Abs(horizontal_direction) > 0.3)
        {
            animator.SetBool("Moving", true);
        }
        else if (Mathf.Abs(horizontal_direction) <= 0.3)
        {
            animator.SetBool("Moving", false);
        }

    }

    private void Jump()
    {
        if (is_grounded)
        {
            int random_sound = Random.Range(0, jump_sounds.Count);
            audio_player.PlayOneShot(jump_sounds[random_sound]);
            rigid_body.AddForce(new Vector2(0, jump_force));
        }
    }

    private void GroundCheck()
    {
        if (foot_collider.IsTouchingLayers(grounded_layer_mask))
        {
            is_grounded = true;
            animator.SetBool("Airborne", false);
        }
        else
        {
            is_grounded = false;
            animator.SetBool("Airborne", true);
        }
    }

    // this comment is wothless

    private void RemoveHitstun()
    {
        rigid_body.velocity = Vector2.zero;
        can_move = true;
        animator.SetBool("Hitstun", false);
    }


    public void TakeDamage(int damage = 1)
    {
        current_health -= damage;
        audio_player.PlayOneShot(damage_sound);
        if (current_health <= 0)
        {
            Respawn();
        }
    }

    public void TakeKnockback(Vector2 direction, float force)
    {
        rigid_body.velocity = direction.normalized * force;
        can_move = false;
        animator.SetBool("Hitstun", true);
        Invoke("RemoveHitstun", 0.5f);
    }

    public int GetHealth()
    {
        return current_health;
    }

    public int GetScore()
    {
        return points;
    }

    private void Respawn()
    {
        RemoveHitstun();
        transform.position = spawn_position.position;
        current_health = starting_health;
    }




    

}
