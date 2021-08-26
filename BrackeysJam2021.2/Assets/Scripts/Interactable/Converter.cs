using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [Header("Conversion Dictionary")]
    [SerializeField]
    private List<string> ingredients;
    [SerializeField]
    private List<GameObject> convertedIngredients;

    private Dictionary<string, GameObject> conversions;

    private void Awake()
    {
        conversions = new Dictionary<string, GameObject>();
        for (int i = 0; i < Mathf.Min(ingredients.Count, convertedIngredients.Count); i++)
        {
            conversions.Add(ingredients[i], convertedIngredients[i]);
        }
    }

    public void CovertIngredient(Ingredient ingredient)
    {
        foreach (KeyValuePair<string, GameObject> entry in conversions)
        {
            if (string.Equals(entry.Key, ingredient.Name))
            {
                Instantiate(entry.Value, ingredient.transform.position, Quaternion.identity);
                Destroy(ingredient.gameObject);
                return;
            }
        }
    }
}
