using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    [SerializeField] private Transform spawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage(1, 0);
            other.transform.position = spawnPosition.position;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
