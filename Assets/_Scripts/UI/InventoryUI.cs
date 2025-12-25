using UnityEngine;
using UnityEngine.UI; // For UI components Image, Button, etc.
using TMPro; // For TextMeshPro components

public class InventoryUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject inventoryPanel; // The main inventory panel
    [SerializeField] private Image itemIcon; // UI element to display item icon
    [SerializeField] private TextMeshProUGUI itemNameText; // UI element to display item name


    private void Awake()
    {
        inventoryPanel.SetActive(false); // Hide inventory panel at start

    }
    private void OnEnable()
    {
        // Subscribe to the item collected event
        GameEvents.OnItemCollected += UpdateInventoryUI;
    }

    private void OnDisable()
    {
        // Unsubscribe from the item collected event
        GameEvents.OnItemCollected -= UpdateInventoryUI;
    }

    void UpdateInventoryUI(ItemSO item)
    {
        // Update the inventory UI with the collected item details
        if (item != null)
        {
            inventoryPanel.SetActive(true);
            itemIcon.sprite = item.ItemIcon;
            itemNameText.text = item.ItemName;
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }
}
