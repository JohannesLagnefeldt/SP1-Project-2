using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public int damage;
    public float knockback;

    [SerializeField] private Enemy enemy;

    private float x;

    private void Start()
    {
        x = transform.localPosition.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Damage(damage, (float) enemy.direction * knockback);
        }
    }

    private void Update()
    {
        if(enemy.direction == Enemy.facing.left)
        {
            transform.localPosition = new Vector3(-x, transform.localPosition.y, transform.localPosition.z);
            print(transform.localPosition);
        }
        if (enemy.direction == Enemy.facing.right)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
            print(transform.localPosition);
        }
    }
}
