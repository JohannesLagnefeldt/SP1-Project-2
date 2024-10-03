using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomTrigger : MonoBehaviour
{

    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Vector3 newZoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCamera.GetComponent<CameraFollow>().offset = newZoom;
            Destroy(gameObject);
        }
    }
}
