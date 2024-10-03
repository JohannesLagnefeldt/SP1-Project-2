using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [SerializeField] private GameObject text_box;
    private void OnTriggerExit2D(Collider2D collision)
    {
        text_box.SetActive(false);
        Destroy(gameObject);
    }
}
