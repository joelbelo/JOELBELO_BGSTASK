using UnityEngine;

[CreateAssetMenu(fileName = "Gear", menuName = "ScriptableObjects/Gear", order = 2)]
public class Gear : Item
{
    public GearSlot Slot;
}

public enum GearSlot
{
    Head,
    Chest,
    Legs
}