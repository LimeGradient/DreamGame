using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private CraftingManager craftingManager;
    public bool NearCraftingStation = false;
    [SerializeField] private GameObject craftingMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearCraftingStation)
        {
            if(craftingMenu.activeSelf == false)
            {
                craftingMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                craftingMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    public void ChooseRecipe(int recipeId)
    {
        craftingManager.RecipeCheck(recipeId);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CraftingStation"))
        {
            NearCraftingStation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CraftingStation"))
        {
            NearCraftingStation = false;
        }
    }
}
