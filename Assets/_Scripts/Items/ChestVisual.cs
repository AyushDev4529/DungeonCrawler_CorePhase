using UnityEngine;

public class ChestVisual : MonoBehaviour
{
    [SerializeField] SpriteRenderer chestVisual;
    [SerializeField] Sprite openChestSprite;
    [SerializeField] Sprite closeChestSprite;
    [SerializeField] Chest chest;

    private void OnEnable()
    {
        chest.OnChestOpened += ChestOpen;
        if (chest.IsOpen) ChestOpen();

    }

    private void OnDisable()
    {
        chest.OnChestOpened -= ChestOpen;
        ChestClose();
    }

    void ChestOpen()
    {
        Debug.Log("Chest Visual Opened");
        chestVisual.sprite = openChestSprite;
    }
    void ChestClose()
    {
        chestVisual.sprite = closeChestSprite;
    }

}

