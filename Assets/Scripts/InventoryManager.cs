using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    [SerializeField] private PlayerInventory playerInventory;

    public void AddItemToInventory(int id, int count)
    {
        int _addCount = playerInventory.UpdatePlayerInventory(id, count);
        items[id].count += count;
        if (_addCount != count)
        {
            int _dropCount = count - _addCount;
            //later will drop items
        }
        playerInventory.UpdateHotbarUI();
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