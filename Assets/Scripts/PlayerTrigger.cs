using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Interactable _currentInteractable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Interactable")) return;
        
        _currentInteractable=other.GetComponent<Interactable>();
        _currentInteractable.EnablePrompt(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Interactable")) return;
        
        _currentInteractable.EnablePrompt(false);
        _currentInteractable = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.Interact();
            }
        }
    }
}