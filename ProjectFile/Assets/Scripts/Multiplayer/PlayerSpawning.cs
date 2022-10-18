using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns the player in different locations
public class PlayerSpawning : MonoBehaviour
{
    public GameObject[] players = new GameObject[4];
    public Transform[] spawnPos = new Transform[4];
    public Material[] mats = new Material[4];
    public InventoryObject[] inv = new InventoryObject[4];


    public void MovePlayersToStart()
    {
        foreach(GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);

                go.transform.position = spawnPos[Index].position;
                go.transform.eulerAngles = Vector3.zero;
                go.transform.GetChild(0).GetComponent<MeshRenderer>().material = mats[Index];
                go.GetComponent<CharacterMovement>().inventory = inv[Index];
            }
        }
    }
}
