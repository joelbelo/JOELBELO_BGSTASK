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
    public void Init(List<Item> items, string title)
    {
        base.Init();
        _shopTitle.text = title;
        _btnClose.onClick.RemoveAllListeners();
        _btnClose.onClick.AddListener(Close);


        foreach (Transform t in _content)
        {
            Destroy(t.gameObject);
        }

        foreach (Item s in items)
        {
            Instantiate(_prefabItem, _content, false).Init(s);
        }
    }

}