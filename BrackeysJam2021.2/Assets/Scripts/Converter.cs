using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChaosAlchemy;

public class Converter : MonoBehaviour
{
    [Header("Conversion Dictionary")]
    [SerializeField]
    private List<IngredientType> ingredients;
    [SerializeField]
    private List<GameObject> convertedIngredients;

    private Dictionary<IngredientType, GameObject> conversions;

    private void Awake()
    {
        conversions = new Dictionary<IngredientType, GameObject>();
        for (int i = 0; i < Mathf.Min(ingredients.Count, convertedIngredients.Count); i++)
        {
            conversions.Add(ingredients[i], convertedIngredients[i]);
        }
    }

    public void CovertIngredient(Ingredient ingredient)
    {
        foreach (KeyValuePair<IngredientType, GameObject> entry in conversions)
        {
            if (string.Equals(entry.Key, ingredient._ingredientType))
            {
                Instantiate(entry.Value, ingredient.transform.position, Quaternion.identity);
                Destroy(ingredient.gameObject);
                return;
            }
        }
    }
}