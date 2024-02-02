using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private ClosetPanel _closetPanel;
    
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

    public void OpenShopPanel(List<Item> items, string title)
    {
        _shopPanel.gameObject.SetActive(true);
        _shopPanel.Init(items, title);
    }

    public void OpenClosetPanel()
    {
        _closetPanel.gameObject.SetActive(true);
        _closetPanel.Init();
    }

    public void UpdateUI()
    {
        _goldText.text = ItemManager.Instance.GetItemCount("Gold").ToString();
    }
}