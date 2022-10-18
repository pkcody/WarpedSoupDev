using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMessager : MonoBehaviour
{
    private void OnPlayerJoined(PlayerInput player)
    {
        print("death");
        FindObjectOfType<PlayerSpawning>().players[PlayerInputManager.instance.playerCount - 1] = player.gameObject;
        FindObjectOfType<PlayerSpawning>().MovePlayersToStart();

    }

    private void OnPlayerLeft(PlayerInput player)
    {

        print("moredeath");
    }

}
