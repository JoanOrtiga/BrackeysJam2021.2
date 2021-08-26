using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsChecker : MonoBehaviour
{
    public delegate void OnIngredientUsedDelegate(string name);
    public static OnIngredientUsedDelegate ingredientUsedDelegate;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponent("Ingredient") as Ingredient) != null)
        {
            var ingredient = other.GetComponent("Ingredient") as Ingredient;
            ingredientUsedDelegate?.Invoke(ingredient.Name);
            Destroy(other.gameObject);
        }
    }
}
