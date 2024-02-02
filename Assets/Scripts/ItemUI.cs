using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private Item _item;

    [SerializeField] private Button _btn;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _equipped;
    
    public void Init(Item item, bool equipped)
    {
        _item = item;
        _icon.sprite = _item.Icon;
        _name.text = _item.Name;
        _btn.onClick.RemoveAllListeners();
        _btn.onClick.AddListener(Equip);
        
        _equipped.enabled = equipped;
    }

    private void Equip()
    {
        
    }
    
}