using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject bridge;

    bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            bridge.GetComponent<Animator>().SetTrigger("Raise");
            GetComponent<Animator>().SetTrigger("Pressed");
            activated = true;
        }
    }
}
