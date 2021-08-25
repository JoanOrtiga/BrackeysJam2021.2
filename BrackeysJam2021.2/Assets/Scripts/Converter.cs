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
        Debug.Log(ingredients.Count + " " + convertedIngredients.Count);
        for (int i = 0; i < Mathf.Min(ingredients.Count, convertedIngredients.Count); i++)
        {
            conversions.Add(ingredients[i], convertedIngredients[i]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.GetComponent("Ingredient") as Ingredient) != null)
        {
            var ingredient = other.GetComponent("Ingredient") as Ingredient;
            ExamineObject.interestingObjects.Remove(other.gameObject);
            CovertIngredient(ingredient);
            Destroy(other.gameObject);
            Debug.Log("Converted");
        }
    }
    private void CovertIngredient(Ingredient ingredient)
    {
        foreach (KeyValuePair<string, GameObject> entry in conversions)
        {
            if (string.Equals(entry.Key, ingredient.IngredientName))
            {
                Instantiate(entry.Value, ingredient.transform.position, Quaternion.identity);
                return;
            }
        }
    }
}
