using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject text_box;
    [SerializeField] private TMP_Text text_object;
    [SerializeField] private int points_to_exit = 1000;

    private void Start()
    {
        text_box.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerMovment>().GetScore() >= points_to_exit)
            {
                text_object.text = "Time to leave";
                Invoke("EndLevel", 10f);
            }
            else
            {
                int score_to_go = points_to_exit - collision.GetComponent<PlayerMovment>().GetScore();
                text_object.text = "I don't have enough money to leave just jet. I need to get atleast " + score_to_go + "$ more before i go."; 
            }
            text_box.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text_box.SetActive(false);
        }
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(2);
    }
}
