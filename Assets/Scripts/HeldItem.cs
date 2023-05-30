using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeldItem : MonoBehaviour
{
    private KeyCode[] numKeys =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0,
    };
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private Image heldItemImage;
    [SerializeField] private BuildTool buildTool;
    [SerializeField] private TMP_Text toolText;
    public int heldItemId;

    void Start()
    {
        SetHeldItem(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!buildTool.isBuilding)
        {
            for (int i = 0; i < numKeys.Length; i++)
            {
                if (Input.GetKeyDown(numKeys[i]))
                {
                    SetHeldItem(i);
                }
            }
        }

    }

    void SetHeldItem(int numKey)
    {
        heldItemId = playerInventory.slotItemIds[numKey];
        if (heldItemId > -1)
        {
            heldItemImage.sprite = inventoryManager.items[heldItemId].icon;
            heldItemImage.color = Color.white;
            toolText.text = inventoryManager.items[heldItemId].name;

        }
        else
        {
            heldItemImage.sprite = null;
            heldItemImage.color = Color.clear;
        }
    }
}
