using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _interactPrompt;

    private void Start()
    {
        EnablePrompt(false);
    }

    public void EnablePrompt(bool enable)
    {
        if (_interactPrompt != null)
        {
            _interactPrompt.SetActive(enable);
        }
        
    }

    public virtual void Interact()
    {
        
    }
}
