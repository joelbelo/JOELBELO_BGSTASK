using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item Item;
    public int Count;

    public InventoryItem(Item item, int count)
    {
        Item = item;
        Count = count;
    }
}
