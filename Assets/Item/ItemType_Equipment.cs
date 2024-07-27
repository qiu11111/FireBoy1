using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName ="New Item Data",menuName ="Equipment")]
public class ItemType_Equipment : ItemData
{
    public EquipmentType equipmentType;
}
