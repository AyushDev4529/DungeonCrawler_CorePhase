using UnityEngine;

//Making an Interactable interface for all interactable objects
public interface IInteractable
{
    void Interact(GameObject obj);
    bool CanInteract();
}

