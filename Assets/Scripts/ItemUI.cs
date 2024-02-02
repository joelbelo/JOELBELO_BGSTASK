using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private InventoryItem _item;

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _count;

    public void Init(InventoryItem item)
    {
        _item = item;
        _icon.sprite = _item.Item.Icon;
        _name.text = _item.Item.Name;
        _count.text = "Have: " + _item.Count;
    }


}