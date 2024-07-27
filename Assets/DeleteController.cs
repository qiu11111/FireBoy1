using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    private SpriteRenderer sr;
    
    public void setupItem(ItemData itemData,Vector2 v)
    {
        this.itemData = itemData;
        GetComponent<Rigidbody2D>().velocity = v;
        GetComponent<SpriteRenderer>().sprite = itemData.sprite;
        gameObject.name = itemData.itemName;
    }
    

    public void addItem()
    {
        Inventory.instane.addItem(itemData);
        Destroy(gameObject);
    }
}
