using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe Object", menuName = "Inventory System/Items/Recipe")]
public class RecipeObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Recipe;
    }
}
