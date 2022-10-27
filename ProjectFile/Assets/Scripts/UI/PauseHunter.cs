using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHunter : MonoBehaviour
{
    private void Start()
    {
        foreach (PauseGameMenu pgm in FindObjectsOfType<PauseGameMenu>())
        {
            pgm.pauseGameMenu = gameObject;
        }
        gameObject.SetActive(false);
    }
}
