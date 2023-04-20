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

    public bool RecipeCheck(int recipeId)
    {
        for (int i = 0; i < Recipes[recipeId].Ingredients.Count; i++)
        {
            if (invMan.items[Recipes[recipeId].Ingredients[i].IngredientId].count >= Recipes[recipeId].Ingredients[i].IngredientAmount)
            {
                Debug.Log("True " + i, this);
            }
            else
            {
                Debug.Log("False");
                return false;
            }

        }
        invMan.items[Recipes[recipeId].ResultId].count += Recipes[recipeId].ResultAmount;
        for (int i = 0; i < Recipes[recipeId].Ingredients.Count; i++)
        {
            invMan.items[Recipes[recipeId].Ingredients[i].IngredientId].count -= Recipes[recipeId].Ingredients[i].IngredientAmount;
        }
        return true;

    }

    [System.Serializable]
    public class Recipe
    {
        public int ResultId;
        public int ResultAmount;
        public List<Ingredient> Ingredients = new List<Ingredient>();
    }

    [System.Serializable]
    public class Ingredient
    {
        public int IngredientId;
        public int IngredientAmount;
    }

}