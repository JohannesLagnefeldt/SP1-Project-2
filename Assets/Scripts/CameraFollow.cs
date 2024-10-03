using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform follow_target;
    [SerializeField] public Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] private float smothing = 1.0f;
    void LateUpdate()
    {
        Vector3 new_position = Vector3.Lerp(transform.position, follow_target.position + offset, smothing * Time.deltaTime);
        transform.position = new_position;
    }
}
