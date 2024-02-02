using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
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