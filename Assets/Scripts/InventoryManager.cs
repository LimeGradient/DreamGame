using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (item.stackable)
        {
            foreach (Item invItem in items)
            {
                if (invItem.id == item.id)
                {
                    invItem.count += item.count;
                    return true;
                }                
            }
        }

        items.Add(item);
        return true;
    }
}

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite icon;
    public bool stackable;
    public int count;
}