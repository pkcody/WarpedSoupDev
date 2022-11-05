using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient Object", menuName = "Inventory System/Items/Ingredient")]
public class IngredientObject : ItemObject
{
    public int Something;
    public void Awake()
    {
        type = ItemType.Ingredient;
    }
}
