using System;
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

    private void Start()
    {
        UpdateUI();
    }

    public void OpenShopPanel(List<Item> items, string title,bool enableSell)
    {
        _shopPanel.gameObject.SetActive(true);
        _shopPanel.Init(items, title,enableSell);
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