using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public int amount = 25;             //sets the amount of ingredients spawned
    public GameObject[] ingredients;

    void Start()
    {
        for (int x = 0; x < amount; x++)
        {
            //ensures that there is at least 1 of each ingredient
            int itemIndex = 0;
            itemIndex += x;
            if (itemIndex >= ingredients.Length)
            {
                itemIndex -= ingredients.Length;
            }
            //int randomIndex = Random.Range(0, ingredients.Length);        //incase someone wants true random spawning
            //checking for larger ingredients and adjusting rotation
            if (itemIndex != 9 && itemIndex != 10 && itemIndex != 12)
            {
                Vector3 randomSpawnPosition = new Vector3(
                    Random.Range(-24, 24), 0, Random.Range(-16.5f, 16.5f));

                Instantiate(ingredients[/*change this to randomIndex for true random*/itemIndex], randomSpawnPosition,
                    Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0));
            }
            else
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-24, 24), 0, Random.Range(-16.5f, 16.5f));
                Instantiate(ingredients[/*change this to randomIndex for true random*/itemIndex],
                    randomSpawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 90));
            }
        }
    }
}