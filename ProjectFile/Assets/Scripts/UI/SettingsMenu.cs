using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button ExitButton;
    public Button StartButton;

    private void Start()
    {
        ExitButton.Select();
        
    }

    public void OnDisable()
    {
        StartButton.Select();
    }

    /*
    public void ToggleSettingsOn()
    {
        if (!settingsGameMenu.activeSelf)
        {
          //  Time.timeScale = 0;
            settingsGameMenu.SetActive(true);
            Debug.Log("Game Settings Open");
        }
    }

    public void ToggleSettingsOff()
    {
        if (settingsGameMenu.activeSelf)
        {
            //  Time.timeScale = 1;
            settingsGameMenu.SetActive(false);
            Debug.Log("Game Settings Close");

        }
    }
    */

}
