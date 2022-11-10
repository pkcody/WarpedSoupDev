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

}
