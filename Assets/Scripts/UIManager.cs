using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private ShopPanel _shopPanel;
    
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

    public void OpenShopPanel(List<ShopItem> items, string title)
    {
        _shopPanel.gameObject.SetActive(true);
        _shopPanel.Init(items, title);
    }
}