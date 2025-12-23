using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Chest : MonoBehaviour, IInteractable
{

    public string ChestID { get; private set; }
    public bool IsOpen { get; private set; }
    [SerializeField] ItemSO items;


    public Action OnChestOpened;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   // Generate a unique ID for the chest
        ChestID = GlobalHelper.GenrateUniqueID(gameObject);

    }


    public bool CanInteract()
    {
        return !IsOpen;
    }

    public void Interact(GameObject interactor)
    {
        if (CanInteract())
        {
            IsOpen = true;
            OnChestOpened?.Invoke();

            if (items != null)
                Debug.Log($"Chest {ChestID} opened by {interactor.name}, containing item: {items.ItemName}");

            else
                Debug.Log($"Chest {ChestID} opened by {interactor.name}, but it is empty.");

        }
        else
        {
            Debug.Log($"Chest {ChestID} is already open.");
            return;
        }

    }

}
