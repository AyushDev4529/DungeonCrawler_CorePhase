using System;
using UnityEngine;

public class GameEvents
{
    // Event triggered when an item is collected
    public static event Action<ItemSO> OnItemCollected;

    // Method to invoke the item collected event
    public static void ItemCollected(ItemSO item)
    {
        OnItemCollected?.Invoke(item);
    }
}
