using System;
using UnityEngine;

[Serializable]
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
