using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    private InventoryManager _inventoryManager;

    public int id;
    public string name;
    public Sprite sprite;
    public bool stackable;
    public int count;

    private void Awake()
    {
        _inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        
        Item item = new Item();
        item.id = this.id;
        item.name = this.name;
        item.icon = this.sprite;
        item.stackable = this.stackable;
        item.count = this.count;
        _inventoryManager.AddItem(item);
    }
}
