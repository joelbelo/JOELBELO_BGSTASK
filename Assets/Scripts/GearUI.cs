using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GearUI : MonoBehaviour
{
    private Gear _item;

    [SerializeField] private Button _btn;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _equipped;
    
    public void Init(Gear item)
    {
        _item = item;
        _icon.sprite = _item.Icon;
        _name.text = _item.Name;
        _btn.onClick.RemoveAllListeners();
        _btn.onClick.AddListener(Equip);
        
        _equipped.enabled = ItemManager.Instance.CheckGearEquipped(_item);
    }

    private void Equip()
    {
        ItemManager.Instance.EquipGear(_item);
        Init(_item);
    }
    
}