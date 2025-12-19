using System;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{

    public string ChestID{ get; private set; }
    public bool IsOpen { get; private set; }
   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   // Generate a unique ID for the chest
        ChestID = GlobalHelper.GenrateUniqueID(gameObject);
    }

    

    public bool CanInteract()
    {
       return !IsOpen;
    }

    public void Interact(GameObject gameObject)
    {
        if (!CanInteract()) return;
        else
        {
            Debug.Log("Chest Interacted by " + gameObject.name);
            
            //OpenChest();
        }

    }
}
