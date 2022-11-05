using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecipeGenerator : MonoBehaviour
{
    public GameObject recipeUI;
    public RecipeScriptableObject Recipe;
    public indexList itemList = new indexList();

    [System.Serializable]
    public class Ingredis
    {
        public List<GameObject> Items;
    }

    [System.Serializable]
    public class indexList
    {
        public List<Ingredis> index;
    }

    // 0 = Meats;
    // 1 = Spice;
    // 2 = vegetables;
    // 3 = wild;
    // how to use: itemList.index[1].Items[1]
    void Start()
    {
        Recipe.Clear();
        for (int i = 0; i < 4; i++)
        {
            int RandomIndex = Random.Range(1, 4);
            GameObject SingleIngrediant = itemList.index[i].Items[RandomIndex];
            Recipe.AddItem(SingleIngrediant.GetComponent<Item>().item,i);
        }
        recipeUI.GetComponent<DisplayRecipe>().display();
    }
    
}
