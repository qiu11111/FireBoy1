using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Equipment : UI_ItemSlot
{
    public EquipmentType equipmentType;
    private void OnValidate()
    {
        gameObject.name = "EquipmentSlot-" + equipmentType.ToString();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Inventory.instane.unEquipmentItem((ItemType_Equipment)data.itemData);
    }
}
