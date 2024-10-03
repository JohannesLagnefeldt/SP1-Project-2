using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.currentHealth;
        score.text = " Score: " + player.points.ToString();
    }
}
