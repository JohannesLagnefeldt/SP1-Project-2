using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip takeDamage;
    [SerializeField] private AudioClip run;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(string clip)
    {
        switch (clip)
        {
            case "Attack":
                audioSource.PlayOneShot(attack);
                break;
            case "Jump":
                audioSource.PlayOneShot(jump);
                break;
            case "Take Damage":
                audioSource.PlayOneShot(takeDamage);
                break;
            case "Run":
                audioSource.loop = true;
                audioSource.PlayOneShot(run);
                break;
        }
    }

    public void StopAudio()
    {
        audioSource.loop = false;
        audioSource.Pause();
        audioSource.Stop();
    }
}


