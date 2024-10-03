using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordHitbox : MonoBehaviour
{
    public int damage;
    public float knockback;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage, knockback * (transform.localPosition.x / 1.8f));
        }
    }

}
