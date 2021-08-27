using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsChecker : MonoBehaviour
{
    public delegate void OnIngredientUsedDelegate(string name);
    public static OnIngredientUsedDelegate ingredientUsedDelegate;
    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        
        if (ingredient != null)
        {
            ingredientUsedDelegate?.Invoke(ingredient.Name);
            Destroy(other.gameObject);
        }
    }
}
