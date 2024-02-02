using UnityEngine;
using UnityEngine.UI;

public class ClosetPanel : UIPanel
{
    [SerializeField] private Button _btnClose;
    [SerializeField] private Transform _content;
    [SerializeField] private GearUI _prefabItem;
    [SerializeField] private Toggle[] _tabs;

    private GearSlot _currentSlot;
    
    public override void Init()
    {
        base.Init();
        _btnClose.onClick.RemoveAllListeners();
        _btnClose.onClick.AddListener(Close);

        foreach (var t in _tabs)
        {
            t.onValueChanged.RemoveAllListeners();
            t.onValueChanged.AddListener((bool on)=>
            {
                UpdateTabs();
            });
        }
        
        ItemManager.Instance.UpdateGear += UpdateTabs;
        
        UpdateTabs();
    }

    private void UpdateTabs()
    {
        for (int i = 0; i < _tabs.Length; i++)
        {
            if (_tabs[i].isOn)
            {
                _currentSlot = (GearSlot)i;
                UpdateList();
            }
        }
    }

    private void UpdateList()
    {
        foreach (Transform t in _content)
        {
            Destroy(t.gameObject);
        }

        foreach (InventoryItem it in ItemManager.Instance.Inventory)
        {
            if (it.Item.Type != ItemType.Gear)
            {
                continue;
            }

            Gear g = (Gear)it.Item;

            if (g.Slot != _currentSlot)
            {
                continue;
            }
            
            Instantiate(_prefabItem,_content,false).Init(g);
        }
    }

}