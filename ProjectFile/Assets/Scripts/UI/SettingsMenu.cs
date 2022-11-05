using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsGameMenu;
    private void Awake()
    {
        settingsGameMenu.SetActive(false);
    }

    public void ToggleSettings()
    {
        if (!settingsGameMenu.activeSelf)
        {
          //  Time.timeScale = 0;
            settingsGameMenu.SetActive(true);
            Debug.Log("Game Settings Open");
        }

        else if (settingsGameMenu.activeSelf)
        {
          //  Time.timeScale = 1;
            settingsGameMenu.SetActive(false);
            Debug.Log("Game Settings Close");

        }
    }

}
