using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("NextLevel", 1f);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
