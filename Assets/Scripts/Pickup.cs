using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private bool isHealingItem;
    [SerializeField] private int health;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private SpriteRenderer sprite;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (isHealingItem)
            {
                if(player.currentHealth < player.maxHealth)
                {
                    player.currentHealth = Mathf.Clamp(player.currentHealth + health, 0, player.maxHealth);
                }
                else
                {
                    return;
                }
            }
            audioPlayer.PlayOneShot(pickupSound);
            player.points += points;
            sprite.color = Color.clear;
            Invoke("disapear", pickupSound.length);
        } 
    }

    private void disapear()
    {
        Destroy(gameObject);
    }
}

