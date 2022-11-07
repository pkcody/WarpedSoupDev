using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMessager : MonoBehaviour
{
    public static PlayerInputMessager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        print("death");
        FindObjectOfType<PlayerSpawning>().players[PlayerInputManager.instance.playerCount - 1] = player.gameObject;
        FindObjectOfType<PlayerSpawning>().SetInitialPlayerValues();

    }

    private void OnPlayerLeft(PlayerInput player)
    {

        print("moredeath");
    }

}
