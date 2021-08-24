using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    public TextMeshPro Name;
    public TextMeshPro Description;
    public TextMeshPro Ingredients;
    public Image Time;

    private void OnEnable()
    {
        RecipesManager.recipeStartDelegate += RecipeStart;
        RecipesManager.timeLeftDelegate += TimeLeft;
    }
    private void OnDisable()
    {
        RecipesManager.recipeStartDelegate -= RecipeStart;
        RecipesManager.timeLeftDelegate -= TimeLeft;
    }

    private void RecipeStart(IRecipe recipe)
    {
        Name.text = recipe.Name;
        Description.text = recipe.Description;
        Ingredients.text = IngredientString(recipe.Ingredients);
    }

    private string IngredientString(Dictionary<string, int> dictionary)
    {
        string ingredients = "";
        foreach(KeyValuePair<string, int> entry in dictionary)
        {
            ingredients += entry.Key + " x" + entry.Value.ToString() + System.Environment.NewLine;
        }
        return ingredients;
    }

    private void TimeLeft(float timeLeftPercentage)
    {
        Time.fillAmount = timeLeftPercentage;
    }
}
