using System.Collections.Generic;
using UnityEngine;

public class Vendor : Interactable
{
    
    [SerializeField] private List<ShopItem> _shopItems;
    [SerializeField] private string _shopTitle;
    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.OpenShopPanel(_shopItems,_shopTitle);
    }
}
