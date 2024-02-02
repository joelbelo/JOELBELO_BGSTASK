using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public List<Item> AllItems;
    public List<InventoryItem> Inventory;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetItemCount(Item item)
    {
        InventoryItem it = Inventory.Find(i => i.Item.Name == item.Name);

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

    public bool SellItem(Item item, int count)
    {
        InventoryItem it = Inventory.Find(i => i.Item.Name == item.Name);
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

}
