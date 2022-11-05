using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngrediantChecker : MonoBehaviour
{
    public RecipeScriptableObject recipe;
    public InventoryObject inventory;
    public int[] count = new int[4];
    public int TotalItemCount;
    public int ScoreCount;
    // Start is called before the first frame update
    void Start()
    {
        TotalItemCount = 0;
        for (int i = 0; i < 4; i++)
        {
            count[i] = 0;
        }
    }
    public void CheckTrigger()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            TotalItemCount += inventory.Container[i].amount;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < inventory.Container.Count; j++)
            {
                if(inventory.Container[j].item == recipe.Container[i])
                {
                    count[i] = inventory.Container[j].amount;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            TotalItemCount -= count[i];
        }

        CalculateScore();

    }

    public void CalculateScore()
    {

    }

}
