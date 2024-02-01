using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Interactable _currentInteractable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vendor"))
        {
            _currentInteractable=other.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Vendor"))
        {
            _currentInteractable = null;
        }
    }
}