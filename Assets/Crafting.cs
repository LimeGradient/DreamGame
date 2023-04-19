using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private CraftingManager craftingManager;
    public bool NearCraftingStation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearCraftingStation)
        {
            if (craftingManager.RecipeCheck())
            {
                Debug.Log("Craft");
            }
        }
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
