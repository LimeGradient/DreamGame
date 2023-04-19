using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public List<Recipe> Recipes = new List<Recipe>();
    [SerializeField] private InventoryManager invMan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool RecipeCheck()
    {
        for (int i = 0; i < Recipes[0].Ingredients.Count; i++)
        {
            if (invMan.items[Recipes[0].Ingredients[i].IngredientId].count >= Recipes[0].Ingredients[i].IngredientAmount)
            {                
                Debug.Log("True " + i, this);
            }
            else
            {
                Debug.Log("False");
                return false;
            }
            
        }
        return true;

    }

    [System.Serializable]
    public class Recipe
    {
        public int ResultId;
        public List<Ingredient> Ingredients = new List<Ingredient>();
    }

    [System.Serializable]
    public class Ingredient
    {
        public int IngredientId;
        public int IngredientAmount;
    }

}
