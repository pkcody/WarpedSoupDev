using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Props Object", menuName = "Inventory System/Items/Props")]
public class PropsObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Props;
    }
}
