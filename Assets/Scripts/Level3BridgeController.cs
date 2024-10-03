using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3BridgeController : MonoBehaviour
{
    [SerializeField] private GameObject samurai;
    [SerializeField] private GameObject cameraZoom;

    [SerializeField] private Transform bridge1, bridge2;

    private bool raised = false;


    void Update()
    {
        if (!samurai && raised)
        {
            bridge1.Rotate(new Vector3(0, 0, 1), -180 * Time.deltaTime);
            bridge2.Rotate(new Vector3(0, 0, 1), 180 * Time.deltaTime);

            if (bridge2.rotation.eulerAngles.z <= 1)
            {
                Destroy(gameObject);
            }
        }

        if (!cameraZoom && !raised)
        {
            bridge1.Rotate(new Vector3(0, 0, 1), 180 * Time.deltaTime);
            bridge2.Rotate(new Vector3(0, 0, 1), -180 * Time.deltaTime);

            if (bridge1.rotation.eulerAngles.z >= 90) 
            {
                raised = true;
            }
        }
    }
}
