using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGameMenu : MonoBehaviour
{
    public bool isPaused;
    public PlayerInput playerInput;
    public GameObject pauseGameMenu;
    public GameObject settingsMenu;

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (!pauseGameMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
                playerInput.SwitchCurrentActionMap("UI");
                pauseGameMenu.SetActive(true);
                //settingsMenu.SetActive(false);
                InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
                Debug.Log("Game Paused");
            }
            else
            {
                Debug.Log("Game already paused");
            }
        }

    }

    public void OnUnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

            if (pauseGameMenu.activeInHierarchy)
            {
                Time.timeScale = 1;
                playerInput.SwitchCurrentActionMap("Player");
                pauseGameMenu.SetActive(false);
                InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
                Debug.Log("Game Unpaused");

            }
            else
            {
                Debug.Log("Game not paused");
            }
        }


    }



}
