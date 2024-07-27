using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI ItemText;

    public InventoryItem data;

    public void updateSlot(InventoryItem data)
    {
        this.data = data;
        if (data != null)
        {
            image.sprite = data.itemData.sprite;
            if (data.stackSize > 1)
            {
                ItemText.text = data.stackSize.ToString();
            }
            else
            {
                ItemText.text = "";
            }
        }
        image.color = Color.white;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (data.itemData.itemType == ItemType.Equipment)
            Inventory.instane.equipItem(data.itemData);
    }

    public void cleanUpSlot()
    {
        data = null;
        image.sprite = null;
        image.color = Color.clear;

        ItemText.text = "";
    }
}
