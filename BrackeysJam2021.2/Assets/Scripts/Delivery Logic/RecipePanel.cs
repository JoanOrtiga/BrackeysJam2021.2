using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    [SerializeReference]
    private TextMeshPro customer;
    [SerializeReference]
    private TextMeshPro name;
    [SerializeReference]
    private TextMeshPro description;
    [SerializeReference]
    private TextMeshPro ingredients;
    [SerializeReference]
    private Image time;
    private void OnEnable()
    {
        OrdersManager.orderStartDelegate += OrderStart;
        OrdersManager.timeLeftDelegate += TimeLeft;
    }
    private void OnDisable()
    {
        OrdersManager.orderStartDelegate -= OrderStart;
        OrdersManager.timeLeftDelegate -= TimeLeft;
    }

    private void OrderStart(IRecipe recipe, ICustomer customerName)
    {
        customer.text = customerName.Name;
        name.text = recipe.Potion;
        description.text = recipe.Description;
        ingredients.text = IngredientString(recipe.Ingredients);
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
        time.fillAmount = timeLeftPercentage;
    }
}
