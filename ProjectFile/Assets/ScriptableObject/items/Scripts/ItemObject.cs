using UnityEngine;
public enum ItemType
{
    Recipe,
    Props,
    Ingredient,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public string itemName;

    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

    public Sprite icon;
}
