using System.Collections.Generic;
using UnityEngine;

public class Closet : Interactable
{
    public override void Interact()
    {
        base.Interact();
        UIManager.Instance.OpenClosetPanel();
    }
}
