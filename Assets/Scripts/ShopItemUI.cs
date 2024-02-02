using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    private ShopItem _item;

    [SerializeField] private Button _btn;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _cost;

    public void Init(ShopItem item)
    {
        _item = item;
        _icon.sprite = _item.Icon;
        _name.text = _item.Name;
        _cost.text = _item.Cost.ToString();
        _btn.onClick.RemoveAllListeners();
        _btn.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        
    }
    
}