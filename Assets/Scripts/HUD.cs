using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider health_slider;
    [SerializeField] private TMP_Text health_text;
    [SerializeField] private TMP_Text score_text;

    private PlayerMovment player_script;

    // Start is called before the first frame update
    void Start()
    {
        player_script = player.GetComponent<PlayerMovment>();
        health_slider.maxValue = player_script.starting_health;
        health_text.text = player_script.starting_health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        health_slider.value = player_script.GetHealth();
        health_text.text = player_script.GetHealth().ToString();
        score_text.text = "$ " + player_script.GetScore().ToString();
    }
}
