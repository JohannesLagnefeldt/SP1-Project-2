using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelExitController : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    [SerializeField] private GameObject[] locks;
    [SerializeField] private GameObject dialougeBox;
    [SerializeField] private TMP_Text dialougeBoxText;
    [SerializeField] private AudioSource openSFX;
    [SerializeField] private GameObject door;
    [SerializeField] private CameraFollow playerCamera;

    private int maxNbrOfLocks = 0;

    private void Start()
    {
        maxNbrOfLocks = NbrOfLocks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCamera.offset += new Vector3(0, 6, 0);
        int currentNbrOfLocks = NbrOfLocks();
        if (currentNbrOfLocks >= maxNbrOfLocks)
        {
            dialougeBox.SetActive(true);

        }
        else if(currentNbrOfLocks <= 0)
        {
            door.SetActive(true);
            openSFX.Play();
            Invoke("NextLevel", 1f);
        }
        else
        {
            dialougeBoxText.text = "I still need to find more keys";
            dialougeBox.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialougeBox.SetActive(false);
        playerCamera.offset -= new Vector3(0, 6, 0);
    }

    private int NbrOfLocks()
    {
        int nbrOfLocks = 0;
        for (int i = 0; i < locks.Length; i++)
        {
            if (locks[i])
            {
                nbrOfLocks++;
            }
        }
        return nbrOfLocks;
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
