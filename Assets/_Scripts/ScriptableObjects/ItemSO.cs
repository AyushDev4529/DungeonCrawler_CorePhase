using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class ItemSO : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        Consumable,
        Equipment,
        Quest,
        Miscellaneous

    }
    [SerializeField] string itemName;
    public string ItemName => itemName;
    [SerializeField] Sprite itemIcon;
    public Sprite ItemIcon => itemIcon;
    [TextArea]
    [SerializeField] string itemDescription;
    public string ItemDescription => itemDescription;
    [SerializeField] ItemType itemType;
    public ItemType Type => itemType;



}
