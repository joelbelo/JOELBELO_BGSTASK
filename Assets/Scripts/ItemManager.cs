using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public List<Item> AllItems;
    public List<InventoryItem> Inventory;

    public Item Gold;

    public Item Head, Chest, Legs;

    public Action UpdateGear;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            AddItem(Head);
            AddItem(Chest);
            AddItem(Legs);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetItemCount(string item)
    {
        InventoryItem it = Inventory.Find(i => i.Item.Name == item);

        if (it != null)
        {
            return it.Count;
        }
        
        return 0;
        
    }

    public void AddItem(Item item, int count=1)
    {
        InventoryItem it = Inventory.Find(i => i.Item.Name == item.Name);

        if (it != null)
        {
            it.Count += count;
        }
        else
        {
            Inventory.Add(new InventoryItem(item,count));
        }
    }

    public bool UseCurrency(string currency, int count)
    {
        InventoryItem it = Inventory.Find(i => i.Item.Name == currency);
        if (it.Count >= count)
        {
            it.Count -= count;
            if (it.Count == 0)
            {
                Inventory.Remove(it);
            }
            return true;
        }
        
        return false;
        
    }

    public bool SellItem(Item item)
    {
        InventoryItem it = Inventory.Find(i => i.Item.Name == item.Name);
        if (it != null)
        {
            it.Count--;
            AddItem(Gold,item.Value);
            if (it.Count <= 0)
            {
                Inventory.Remove(it);
            }

            return true;
        }

        return false;
    }

    public void EquipGear(Gear gear)
    {
        switch (gear.Slot)
        {
            case GearSlot.Head:
                Head = gear;
                break;
            case GearSlot.Chest:
                Chest = gear;
                break;
            case GearSlot.Legs:
                Legs = gear;
                break;
        }
        
        UpdateGear.Invoke();
    }

    public bool CheckGearEquipped(Gear gear)
    {
        switch (gear.Slot)
        {
            case GearSlot.Head:
                if (Head.Name == gear.Name)
                {
                    return true;
                }
                break;
            case GearSlot.Chest:
                if (Chest.Name == gear.Name)
                {
                    return true;
                }
                break;
            case GearSlot.Legs:
                if (Legs.Name == gear.Name)
                {
                    return true;
                }
                break;
        }

        return false;
    }

}
