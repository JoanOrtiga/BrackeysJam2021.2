using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsChecker : MonoBehaviour
{
    public delegate void OnIngredientThrownDelegate(string type);
    public static OnIngredientThrownDelegate ingredientThrownDelegate;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.GetComponent("Ingredient") as Ingredient) != null)
        {
            var ingredient = collision.collider.GetComponent("Ingredient") as Ingredient;
            ingredientThrownDelegate?.Invoke(ingredient.Name);
        }
    }
}
