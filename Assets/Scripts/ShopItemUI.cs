using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    private Item _item;

    [SerializeField] private Button _btn;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _have;
    [SerializeField] private TMP_Text _owned;
    
    public void Init(Item item, bool sellMode)
    {
        _item = item;
        _icon.sprite = _item.Icon;
        _name.text = _item.Name;
        _cost.gameObject.SetActive(true);
        _cost.text = _item.Value.ToString();
        
        _btn.onClick.RemoveAllListeners();
        
        //Already got gear
        if (item.Type == ItemType.Gear)
        {
            if (ItemManager.Instance.GetItemCount(item.Name) > 0)
            {
                _cost.gameObject.SetActive(false);
                _owned.gameObject.SetActive(true);
                return;
            }
        }

        if (sellMode)
        {
            _cost.text = item.Value.ToString();
            _have.gameObject.SetActive(true);
            _have.text = "Have : " + ItemManager.Instance.GetItemCount(item.Name);
        }
        
        _btn.onClick.AddListener(sellMode ? SellItem : BuyItem);
    }

    private void BuyItem()
    {
        if (ItemManager.Instance.UseCurrency("Gold", _item.Value))
        {
            ItemManager.Instance.AddItem(_item);
            UIManager.Instance.UpdateUI();
            Init(_item,false);
        }
    }

    private void SellItem()
    {
        ItemManager.Instance.SellItem(_item);
        Init(_item,true);
        UIManager.Instance.UpdateUI();
    }
    
}