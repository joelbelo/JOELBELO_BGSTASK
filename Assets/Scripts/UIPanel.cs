using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public virtual void Init()
    {
        
    }
    protected virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
