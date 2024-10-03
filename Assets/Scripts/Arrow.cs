using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    
    public float speed;
    public int damage;
    public float knokback;
    public float timeToDestroy;

    private float destroyT;
    private float direction;

    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        destroyT += Time.deltaTime;
        if(destroyT > timeToDestroy)
        {
            Destroy(gameObject);
        }


        rigidbody2d.velocity = new Vector2 (speed * Time.deltaTime * direction, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("hit");
            collision.gameObject.GetComponent<Player>().Damage(damage, direction * knokback);
            Destroy(gameObject);
        }
    }

    public void setDirection(float direction)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (direction > 0)
        {
            sprite.flipX = false;
        }
        else if (direction < 0)
        {
            sprite.flipX = true;
        }

        this.direction = direction;
    }
}
