using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject pairedLock;
    [SerializeField] private AudioClip pickupSound;

    private AudioSource audioPlayer;
    private SpriteRenderer sprite;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioPlayer.PlayOneShot(pickupSound);
            sprite.color = Color.clear;
            Invoke("disapear", pickupSound.length);
            Destroy(pairedLock);
            
        }


    }

    private void disapear()
    {
        Destroy(gameObject);
    }
}
