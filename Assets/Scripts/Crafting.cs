using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private CraftingManager craftingManager;
    public bool NearCraftingStation = false;
    [SerializeField] private GameObject craftingMenu;
    [SerializeField] private SC_FPSController playerCon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearCraftingStation)
        {
            if (!craftingMenu.activeSelf && playerCon.canMove)
            {
                craftingMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                playerCon.canMove = false;
            }
            else if (craftingMenu.activeSelf)
            {
                craftingMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerCon.canMove = true;
            }

        }
    }

    public void ChooseRecipe(int recipeId)
    {
        craftingManager.RecipeCheck(recipeId);
    }

    public void HandChooseRecipe(int recipeId)
    {
        craftingManager.HandRecipeCheck(recipeId);
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
