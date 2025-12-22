using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Chest : MonoBehaviour, IInteractable
{

    public string ChestID { get; private set; }
    public bool IsOpen { get; private set; }


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
            //Debug.Log("Chest Interacted by " + interactor.name);
            IsOpen = true;
            OnChestOpened?.Invoke();
        }
        else
        {
            return;
        }

    }

}
