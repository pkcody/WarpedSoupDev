using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public int amount = 8;
    public GameObject[] clouds;

    void Start()
    {
        for(int x = 0; x < amount; x++)
        {
            int randomIndex = Random.Range(0, clouds.Length);

            Vector3 randomSpawnPosition = new Vector3(Random.Range(-40f, 20f), 10, Random.Range(-12f, 8f));
            GameObject cloud = Instantiate(clouds[randomIndex], randomSpawnPosition, Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0));
        }
    }
}
