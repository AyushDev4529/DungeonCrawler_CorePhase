using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<string,ItemSO> InventoryItems = new Dictionary<string, ItemSO>();

    void OnEnable()
    {
        // Subscribe to the item collected event
        GameEvents.OnItemCollected += AddItemToInventory;
    }

    void OnDisable()
    {
        // Unsubscribe from the item collected event
        GameEvents.OnItemCollected -= AddItemToInventory;
    }

    void AddItemToInventory(ItemSO item)
    {
        if (item != null && !InventoryItems.ContainsKey(item.ItemName))
        {
            InventoryItems.Add(item.ItemName, item);
            Debug.Log($"Item {item.ItemName} added to inventory.");
        }
        else
        {
            Debug.LogWarning($"Item {item?.ItemName} is already in inventory or is null.");
        }
    }

    public bool HasItem(ItemSO item)
    {
        if (item != null && InventoryItems.ContainsKey(item.ItemName))
        {
            Debug.Log($"Inventory contains item: {item.ItemName}");
            return true;
            
        }
        else
        {
            Debug.Log($"Inventory does not contain item: {item?.ItemName}");
            return false;
            
        }
    }

    public void RemoveItem(ItemSO item) {
        if (item != null && InventoryItems.ContainsKey(item.ItemName))
        {
            InventoryItems.Remove(item.ItemName);
            Debug.Log($"Item {item.ItemName} removed from inventory.");
        }
        else
        {
            Debug.LogWarning($"Item {item?.ItemName} not found in inventory or is null.");
        }
    }

}
