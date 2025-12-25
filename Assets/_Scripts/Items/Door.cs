using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    
    [SerializeField] private ItemSO keyItem; // The item required to unlock the door
    [SerializeField] private BoxCollider2D doorCollider;// The collider representing the door area to disable when open
    

    private bool isOpen = false;

    public bool CanInteract()
    {
        return !isOpen;
    }

    public void Interact(GameObject interactor)
    {
        if(CanInteract())
        {
            TryUnlock(interactor);
        }
        else
        {
            Debug.Log("The door is already open.");
        }
    }

    private void TryUnlock(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();
        if (inventory != null && inventory.HasItem(keyItem))
        {
            OpenDoor();
            //inventory.RemoveItem(keyItem) - inventory will not remove the key on use
        }
        else
        {
            // Optionally, provide feedback that the door is locked
            Debug.Log("The door is locked. You need a key to open it.");
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        // Disable the collider to allow passage
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
            GameObject.Destroy(gameObject, 0.5f); // Optionally destroy the door object after a short delay
        }
        // Optionally, play an animation or sound effect here
    }

}
