using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory System/Recipes")]
public class RecipeScriptableObject : ScriptableObject
{
    public List<ItemObject> Container = new List<ItemObject>(new ItemObject[4]);
    public void AddItem(ItemObject _item,int index)
    {
        Debug.Log(index);
        Container[index] = _item;
    }
    public void Clear()
    {
        for(int i = 0; i < 4; i++)
        {
            Container[i] = null;
        }
    }
}
