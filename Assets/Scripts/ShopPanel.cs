using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : UIPanel
{
    [SerializeField] private TMP_Text _shopTitle;
    [SerializeField] private Button _btnClose;

    [SerializeField] private Transform _content;
    [SerializeField] private ShopItemUI _prefabItem;
    
    [SerializeField] private Toggle[] _tabs;

    private bool _sellMode = false;

    private List<Item> _items;
    private string _title;
    private bool _enableSell;
    
    public void Init(List<Item> items, string title,bool enableSell)
    {
        base.Init();
        
        _items = items;
        _title = title;
        _enableSell = enableSell;
        _shopTitle.text = title;
        _btnClose.onClick.RemoveAllListeners();
        _btnClose.onClick.AddListener(Close);

        foreach (var t in _tabs)
        {
            t.gameObject.SetActive(_enableSell);
        }
        
        if (_enableSell)
        {
            foreach (var t in _tabs)
            {
                t.onValueChanged.RemoveAllListeners();
                t.onValueChanged.AddListener((bool on)=>
                {
                    UpdateTabs();
                });
            }
        }

        foreach (Transform t in _content)
        {
            Destroy(t.gameObject);
        }

        if (!_sellMode)
        {
            foreach (Item s in items)
            {
                Instantiate(_prefabItem, _content, false).Init(s,false);
            }
        }
        else
        {
            foreach (InventoryItem s in ItemManager.Instance.Inventory)
            {
                if (s.Item.Type == ItemType.Gear || s.Item.Type == ItemType.Currency)
                {
                    continue;
                }
                
                Instantiate(_prefabItem, _content, false).Init(s.Item,true);
            }
        }
        
    }
    
    private void UpdateTabs()
    {
        _sellMode = _tabs[1].isOn;
        Init(_items,_title,_enableSell);
    }

}