using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BackToMenu", 10f);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
