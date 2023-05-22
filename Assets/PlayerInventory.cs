using Mirror;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private SC_FPSController playerCon;
    [SerializeField] private InventoryManager inventoryManager;
    public GameObject inventoryPanel;
    [SerializeField] private List<GameObject> slots;
    public List<int> slotsToUpdate;
    public List<int> slotItemIds;
    [SerializeField] private List<int> slotItemCount;
    private bool visible = false;
    [SerializeField] private int stackSize = 99;
    [SerializeField] private GameObject draggableItem;
    private int draggedItemId = -1;
    private int draggedItemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(visible);
        GiveStartingItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (playerCon.canMove == !visible)
            {
                visible = !visible;
                Cursor.visible = visible;
                playerCon.canMove = !visible;
                if (visible)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                inventoryPanel.SetActive(visible);
                draggableItem.SetActive(visible);
            }
        }
        if (visible)
        {
            UpdateInventoryUI();
        }
    }
    void GiveStartingItems()
    {
        for (int i = 0; i < inventoryManager.items.Count; i++)
        {
            if (inventoryManager.items[i].count > 0)
            {
                UpdatePlayerInventory(i, inventoryManager.items[i].count);
            }
            else
            {
                inventoryManager.items[i].count = 0;
            }
            
        }
        UpdateHotbarUI();

    }

    public int UpdatePlayerInventory(int id, int count)
    {
        if (inventoryManager.items[id].stackable)
        {
            if(count > 0)
            {
                int _remainingStack = PositiveStackableItem(id, count);
                return count - _remainingStack;
            }
            else
            {
                int _remainingStack = NegativeStackableItem(id, count);
                return count + _remainingStack;
            }
        }
        else
        {
            int _remainingStack = NonStackableItem(id, count);
            return count - _remainingStack;
        }
    }

    private void UpdateInventoryUI()
    {
        foreach (int slot in slotsToUpdate)
        {
            Image _slotImage = slots[slot].GetComponent<Image>();
            if (slotItemIds[slot] > -1)
            {
                _slotImage.sprite = inventoryManager.items[slotItemIds[slot]].icon;
                _slotImage.color = Color.white;
            }
            else
            {
                _slotImage.sprite = null;
                _slotImage.color = Color.clear;
            }
            if (slotItemCount[slot] > 1)
            {
                slots[slot].GetComponentInChildren<Text>().text = slotItemCount[slot].ToString();
            }
            else
            {
                slots[slot].GetComponentInChildren<Text>().text = "";
            }
        }
        slotsToUpdate.Clear();
    }

    public void UpdateHotbarUI()
    {
        //slotPos[slotId].GetComponent<Image>().sprite = inventoryManager.items[id].icon;
        //slotPos[slotId].GetChild(0).GetComponent<Text>().text = inventoryManager.items[id].count.ToString();
        for (int i = 0; i < 10; i++)
        {
            Image _slotImage = slots[i].GetComponent<Image>();
            if (slotItemIds[i] > -1)
            {
                _slotImage.sprite = inventoryManager.items[slotItemIds[i]].icon;
                _slotImage.color = Color.white;
            }
            else
            {
                _slotImage.sprite = null;
                _slotImage.color= Color.clear;
            }
            if (slotItemCount[i] > 1)
            {
                slots[i].GetComponentInChildren<Text>().text = slotItemCount[i].ToString();
            }
            else
            {
                slots[i].GetComponentInChildren<Text>().text = "";
            }

        }
    }

    private int PositiveStackableItem(int id, int count)
    {
        for (int i = 0; i < 25; i++)
        {
            if (slotItemIds[i] == id)
            {
                int _stackLeft = stackSize - slotItemCount[i];
                if (_stackLeft >= count)
                {
                    slotItemCount[i] += count;
                    if (!slotsToUpdate.Contains(i))
                    {
                        slotsToUpdate.Add(i);
                    }
                    return 0;
                }
                else
                {
                    count -= _stackLeft;
                    slotItemCount[i] += _stackLeft;
                    if (!slotsToUpdate.Contains(i))
                    {
                        slotsToUpdate.Add(i);
                    }
                    if (count == 0)
                    {
                        return count;
                    }
                }
            }
        }
        if (count > 0)
        {
            for (int i = 0; i < 25; i++)
            {
                if (slotItemIds[i] == -1)
                {
                    if (count < stackSize)
                    {
                        slotItemIds[i] = id;
                        slotItemCount[i] = count;
                        if (!slotsToUpdate.Contains(i))
                        {
                            slotsToUpdate.Add(i);
                        }
                        return 0;
                    }
                    else
                    {
                        count -= stackSize;
                        slotItemIds[i] = id;
                        slotItemCount[i] = stackSize;
                        if (!slotsToUpdate.Contains(i))
                        {
                            slotsToUpdate.Add(i);
                        }
                        if (count == 0)
                        {
                            return count;
                        }
                    }
                }
            }
        }
        return count;
    }

    private int NegativeStackableItem(int id, int count)
    {
        for (int i = 0; i < 25; i++)
        {
            if (slotItemIds[i] == id)
            {
                if (slotItemCount[i] > Math.Abs(count))
                {
                    slotItemCount[i] += count;
                    if (!slotsToUpdate.Contains(i))
                    {
                        slotsToUpdate.Add(i);
                    }
                    return 0;
                }
                else
                {
                    count += slotItemCount[i];
                    slotItemCount[i] = 0;
                    slotItemIds[i] = -1;
                    if (!slotsToUpdate.Contains(i))
                    {
                        slotsToUpdate.Add(i);
                    }
                    if (count == 0)
                    {
                        return count;
                    }
                }
            }
        }
        return count;
    }

    private int NonStackableItem(int id, int count)
    {
        for (int i = 0; i < 25; i++)
        {
            if (slotItemIds[i] == -1)
            {
                if (!slotsToUpdate.Contains(i))
                {
                    slotsToUpdate.Add(i);
                }
                slotItemIds[i] = id;
                slotItemCount[i] = 1;
                count--;
            }
            if (count == 0)
            {
                return count;
            }
        }
        return count;

    }

    public void DragItem(int slotId)
    {
        if (!draggableItem.activeSelf)
        {
            return;
        }
        Image _dragImage = draggableItem.GetComponent<Image>();
        int _itemToPlaceId = draggedItemId;
        int _itemToPlaceCount = draggedItemCount;
        
        draggedItemId = slotItemIds[slotId];
        draggedItemCount = slotItemCount[slotId];
        if(draggedItemId > -1)
        {
            _dragImage.sprite = inventoryManager.items[draggedItemId].icon;
            _dragImage.color = Color.white;
        }
        else
        {
            _dragImage.sprite = null;
            _dragImage.color = Color.clear;
        }
        if (slotItemCount[slotId] > 1)
        {
            draggableItem.GetComponentInChildren<Text>().text = slotItemCount[slotId].ToString();
        }
        else
        {
            draggableItem.GetComponentInChildren<Text>().text = "";
        }
        slotItemIds[slotId] = _itemToPlaceId;
        slotItemCount[slotId] = _itemToPlaceCount;
        if (!slotsToUpdate.Contains(slotId))
        {
            slotsToUpdate.Add(slotId);
        }

    } 

}