using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientFall : MonoBehaviour
{
    private float timeRemaining = 1f;
    public int amount = 17;
    private int counter = 15;
    public GameObject[] ingredients;

    void FixedUpdate()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            int randomIndex = Random.Range(0, ingredients.Length - 1);
            int specialIndex = ingredients.Length - 1;

            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 12, -20);
            GameObject ingredient;
            if (counter == 0)
            {
                ingredient = Instantiate(ingredients[specialIndex], randomSpawnPosition, Quaternion.Euler(Random.Range(-40, -20), 0, Random.Range(-90, 90)));
                counter = Random.Range(10, 20);
            }
            else
            {
                ingredient = Instantiate(ingredients[randomIndex], randomSpawnPosition, Quaternion.Euler(Random.Range(-40, -20), 0, Random.Range(-90, 90)));
            }

            transform.position += new Vector3(0, -0.5f, 0);
            ingredient.AddComponent<FallTime>();
            Destroy(ingredient, 6);
            timeRemaining = 3f;
            counter--;
        }
    }
}
