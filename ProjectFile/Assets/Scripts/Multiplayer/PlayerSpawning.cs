using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

//Spawns the player in different locations
public class PlayerSpawning : MonoBehaviour
{
    public static PlayerSpawning instance;

    public GameObject[] players = new GameObject[4];
    public Material[] mats = new Material[4];
    public InventoryObject[] inv = new InventoryObject[4];

    public Transform[] MenuSpawnPos = new Transform[4];
    public Transform[] CollectSpawnPos = new Transform[4];
    public Transform[] MakeSpawnPos = new Transform[4];

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangePlayerInput()
    {
        foreach(GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);

                // Different spawns for each scene
                if (SceneManager.GetActiveScene().name == "Menu")
                {
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                    print("calling");
                    go.GetComponent<PlayerInput>().defaultActionMap = "UI";
                }
                else if (SceneManager.GetActiveScene().name == "CollectGameSide")
                {
                    print("pizza");
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                    go.GetComponent<PlayerInput>().defaultActionMap = "Player";
                }
            }
        }
    }

    public void StartingPositions()
    {
        foreach (GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);


                if (SceneManager.GetActiveScene().name == "CollectGameSide")
                {
                    go.transform.position = CollectSpawnPos[Index].position;
                }
                else if (SceneManager.GetActiveScene().name == "MakeGameSide")
                {
                    go.transform.position = MakeSpawnPos[Index].position;
                }
            }
        }
    }

    public void SetInitialPlayerValues()
    {
        foreach(GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);
                go.transform.position = MenuSpawnPos[Index].position;

                go.transform.eulerAngles = Vector3.zero;
                go.transform.GetChild(0).GetComponent<MeshRenderer>().material = mats[Index];
                go.GetComponent<CharacterMovement>().inventory = inv[Index];
            }
        }
    }
}
