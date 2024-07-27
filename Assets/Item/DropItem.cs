using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private ItemData itemData;

    [SerializeField] private ItemData[] possibleItems;
    private List<ItemData> items = new List<ItemData>();
    [SerializeField] private int dropAmount;

    public void generateDrop()
    {
        for(int i = 0; i < possibleItems.Length; i++)
        {
            if (Random.Range(0, 100) < possibleItems[i].rate)
            {
                items.Add(possibleItems[i]);
            }
        }
        for (int i = 0; i < dropAmount; i++)
        {
            ItemData newItem = items[Random.Range(0, items.Count - 1)];
            items.Remove(newItem);
            dropItem(newItem);

        }
    }

    public void dropItem(ItemData itemData1)
    {
        GameObject newDrop=Instantiate(prefab, transform.position+new Vector3(10,0,0), Quaternion.identity);
        Vector2 v = new Vector2(Random.Range(-5, 5), Random.Range(15, 20));
        newDrop.GetComponent<DeleteController>().setupItem(itemData1,v);
    }
}
