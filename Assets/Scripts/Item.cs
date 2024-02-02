using System;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemType Type;
    public string Name;
    public Sprite Icon;
    public int Value;
}

public enum ItemType
{
    Currency, 
    Resource, 
    Gear
}
