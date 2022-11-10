using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHunter : MonoBehaviour
{
    private void Start()
    {
        pauseHunt();
    }

    public void pauseHunt()
    {
        foreach (PauseGameMenu pgm in FindObjectsOfType<PauseGameMenu>())
        {
            pgm.pauseGameMenu = gameObject;
        }
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            gameObject.SetActive(false);
        }

    }
}
