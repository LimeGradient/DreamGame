using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventory;

    public GameObject inventoryPanel;
    public GameObject itemImagePrefab;
    public RectTransform contentPanel;
    
    public List<Image> itemImages = new List<Image>();

    private bool visible = false;

    private void Start()
    {
        inventoryPanel.SetActive(visible);
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            visible = !visible;
            inventoryPanel.SetActive(visible);
        }
        
        if (inventory.items.Count != itemImages.Count && visible)
        {
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        // Clear existing item images
        foreach (Image itemImage in itemImages)
        {
            itemImage.enabled = false;
        }

        // Create item images for each item in the inventory
        int i = 0;
        foreach (Item item in inventory.items)
        {
            // Try to reuse an existing item image
            Image itemImage;
            if (i < itemImages.Count)
            {
                itemImage = itemImages[i];
            }
            else
            {
                // Create a new item image
                GameObject newItemImageObject = Instantiate(itemImagePrefab);
                newItemImageObject.transform.SetParent(contentPanel, false);
                itemImage = newItemImageObject.GetComponent<Image>();
                itemImages.Add(itemImage);
            }

            // Update item image properties
            itemImage.enabled = true;
            itemImage.sprite = item.icon;
            itemImage.rectTransform.anchoredPosition = new Vector2(300 + i % 5 * 250, -300 - i / 5 * 250);

            // Update item image count display
            Text countText = itemImage.GetComponentInChildren<Text>();
            if (item.stackable)
            {
                countText.text = item.count.ToString();
                countText.enabled = item.count > 1;
            }
            else
            {
                countText.enabled = false;
            }

            if (itemImage.GetComponent<Image>().sprite == null)
            {
                print("found image");
                countText.enabled = false;
            }
            
            i++;
        }

        // Disable extra item images
        for (int j = i; j < itemImages.Count; j++)
        {
            itemImages[j].enabled = false;
        }
    }
}
