using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instane;

    public List<InventoryItem> InventoryItems;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;

    [SerializeField] private Transform InventorySlotParent;
    [SerializeField] private UI_ItemSlot[] itemSlot;

    public List<InventoryItem> stash;
    public Dictionary<ItemData, InventoryItem> stashDictionary;

    [SerializeField] private Transform stashParent;
    [SerializeField] private UI_ItemSlot[] stashSlot;

    public List<InventoryItem> equipment;
    public Dictionary<ItemType_Equipment, InventoryItem> equipmentDictionary;

    [SerializeField] private Transform EquipmentParent;
    [SerializeField] private UI_Equipment[] equipmentSlot;


    private void Awake()
    {
        if (instane != null)
            Destroy(instane.gameObject);
        instane = this;
    }
    private void Start()
    {
        InventoryItems = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<ItemData, InventoryItem>();
        itemSlot = InventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();

        stash = new List<InventoryItem>();
        stashDictionary = new Dictionary<ItemData, InventoryItem>();
        stashSlot = stashParent.GetComponentsInChildren<UI_ItemSlot>();

        equipment = new List<InventoryItem>();
        equipmentDictionary = new Dictionary<ItemType_Equipment, InventoryItem>();

        equipmentSlot = EquipmentParent.GetComponentsInChildren<UI_Equipment>();
    }

    public void equipItem(ItemData itemData)
    {
        ItemType_Equipment newEquipment = itemData as ItemType_Equipment;
        InventoryItem item = new InventoryItem(newEquipment);
        ItemType_Equipment itemToRemove = null;
        foreach(KeyValuePair<ItemType_Equipment,InventoryItem> s in equipmentDictionary)
        {
            if (s.Key.equipmentType == newEquipment.equipmentType)
                itemToRemove = s.Key;
        }
        if (itemToRemove != null)
        {
            if(equipmentDictionary.TryGetValue(itemToRemove,out InventoryItem value))
            {
                equipment.Remove(value);
                equipmentDictionary.Remove(itemToRemove);
            }
            addItem(itemToRemove);
        }
        equipment.Add(item);
        equipmentDictionary.Add(newEquipment, item);
        removeItem(itemData);
        updateSlot();
    }

    public void unEquipmentItem(ItemType_Equipment itemData)
    {
        if(equipmentDictionary.TryGetValue(itemData,out InventoryItem value))
        {
            equipment.Remove(value);
            equipmentDictionary.Remove(itemData);
            addItem(itemData);
            updateSlot();
        }
    }
    //¸üÐÂslot
    public  void updateSlot()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].cleanUpSlot();
        }
        for (int i = 0; i < stashSlot.Length; i++)
        {
            stashSlot[i].cleanUpSlot();
        }
        for(int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].cleanUpSlot();
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            foreach (KeyValuePair < ItemType_Equipment, InventoryItem> item in equipmentDictionary)
            {
                if (item.Key.equipmentType == equipmentSlot[i].equipmentType)
                {
                    equipmentSlot[i].updateSlot(item.Value);
                }
            }
        }
        for(int i = 0; i < InventoryItems.Count; i++)
        {
            itemSlot[i].updateSlot(InventoryItems[i]);
        }
        for(int i = 0; i < stash.Count; i++)
        {
            stashSlot[i].updateSlot(stash[i]);
        }
    }

    //²Ö¿âÌí¼Óitem
    public void addItem(ItemData itemData)
    {
        if (itemData.itemType == ItemType.Equipment)
        {
            if (inventoryDictionary.TryGetValue(itemData, out InventoryItem value))
            {
                value.addStack();
            }
            else
            {
                InventoryItem inventoryItem = new InventoryItem(itemData);
                InventoryItems.Add(inventoryItem);
                inventoryDictionary.Add(itemData, inventoryItem);
            }
            
        }else if (itemData.itemType == ItemType.Material)
        {
            if(stashDictionary.TryGetValue(itemData,out InventoryItem value))
            {
                value.addStack();
            }
            else
            {
                InventoryItem inventItem = new InventoryItem(itemData);
                stash.Add(inventItem);
                stashDictionary.Add(itemData, inventItem);
            }
        }
        updateSlot();

    }

    //É¾³ý 
    public void removeItem(ItemData itemData)
    {
        if(inventoryDictionary.TryGetValue(itemData,out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                InventoryItems.Remove(value);
                inventoryDictionary.Remove(itemData);
            }
            else
            {
                value.removeStack();
            }
        }
        if(stashDictionary.TryGetValue(itemData,out InventoryItem stashValue))
        {
            if (stashValue.stackSize <= 1)
            {
                stash.Remove(stashValue);
                stashDictionary.Remove(itemData);
            }
            else
            {
                stashValue.removeStack();
            }
        }
        updateSlot();
    }

}
