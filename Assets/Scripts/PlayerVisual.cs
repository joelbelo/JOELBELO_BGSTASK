using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public SpriteRenderer Head, Chest, Legs;
    // Start is called before the first frame update
    void Start()
    {
        ItemManager.Instance.UpdateGear += UpdateGear;
        UpdateGear();
    }
    
    private void UpdateGear()
    {
        Head.sprite = ItemManager.Instance.Head != null ? ItemManager.Instance.Head.Icon : null;
        Chest.sprite = ItemManager.Instance.Chest != null ? ItemManager.Instance.Chest.Icon : null;
        Legs.sprite = ItemManager.Instance.Legs != null ? ItemManager.Instance.Legs.Icon : null;
    }
}
