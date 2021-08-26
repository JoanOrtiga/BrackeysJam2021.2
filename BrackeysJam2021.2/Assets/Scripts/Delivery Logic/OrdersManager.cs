using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrdersManager : MonoBehaviour
{
    private void OnEnable()
    {
        IngredientsChecker.ingredientUsedDelegate += IngredientUsed;
        //Create Potion
    }
    private void OnDisable()
    {
        IngredientsChecker.ingredientUsedDelegate -= IngredientUsed;
        //Create Potion
    }

    public delegate void OnOrderStartDelegate(IRecipe recipe, ICustomer customer);
    public static OnOrderStartDelegate orderStartDelegate;
    public delegate void OnTimeLeftDelegate(float timeLeftPercentage);
    public static OnTimeLeftDelegate timeLeftDelegate;

    public delegate void OnShowExplanationDelegate(List<bool> mistakes);
    public static OnShowExplanationDelegate showExplanationDelegate;
    public delegate void OnShowStarsDelegate(float puntuation);
    public static OnShowStarsDelegate showStarsDelegate;
    public delegate void OnShowCustomerDelegate(string customer);
    public static OnShowCustomerDelegate showCustomerDelegate;

    public delegate void OnShowMedianDelegate(float puntuation);
    public static OnShowMedianDelegate showMedianDelegate;

    private IRecipe currentRecipe => RecipesManager.Recipe;
    private ICustomer currentCustomer => CustomersManager.Customer;
    public GameObject currentPotion => PotionsManager.GetPotion(currentRecipe.Potion);
    private Dictionary<string, int> currentIngredients => currentRecipe.Ingredients;
    private float currentDefaultTime => currentRecipe.DefaultTime;

    private bool incorrectIngredients;
    private bool incorrectQuantities;
    private bool slowTime1;
    private bool slowTime2;
    private bool slowTime3;
    private bool perfect;
    private List<bool> mistakes => new List<bool> { incorrectIngredients, incorrectQuantities, slowTime1, slowTime2, slowTime3 , perfect };

    private Dictionary<string, int> usedIngredients;
    private float timeLeft;

    //Puntuation
    List<float> puntuationsList;

    private void Start()
    {
        usedIngredients = new Dictionary<string, int>();
        puntuationsList = new List<float>();

        StartRecipe();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftDelegate?.Invoke(timeLeft / currentDefaultTime);
    }

    private float Median(List<float> putuationsList)
    {
        float sum = 0;
        foreach (int num in puntuationsList)
            sum += num;

        return sum / puntuationsList.Count;
    }

    private bool IncorrectIngredients()
    {
        if (usedIngredients.Count != currentIngredients.Count)
        {
            return true;
        }
        foreach (KeyValuePair<string, int> entry in usedIngredients)
        {
            int value = 0;
            if (!currentIngredients.TryGetValue(entry.Key, out value))
            {
                return true;
            }
        }
        return false;
    }

    public void StartRecipe()
    {
        RecipesManager.SetRandomRecipe();
        CustomersManager.SetRandomCustomer();
        timeLeft = currentDefaultTime;
        orderStartDelegate?.Invoke(currentRecipe, currentCustomer);
    }

    private void IngredientUsed(string name)
    {
        int value = 0;
        if (usedIngredients.TryGetValue(name, out value))
        {
            value++;
            usedIngredients[name] = value;
        }
        else
        {
            usedIngredients.Add(name, 1);
        }
        printIngredients(usedIngredients);
    }

    private void printIngredients(Dictionary<string, int> usedIngredients)
    {
        string ingredients = "";
        foreach (KeyValuePair<string, int> entry in usedIngredients)
        {
            ingredients += entry.Key + " x" + entry.Value.ToString() + " / ";
        }
        Debug.Log(ingredients);
    }

    public GameObject PotionDone()
    {
        if (!DictionaryExtensionMethods.ContentEquals(currentIngredients, usedIngredients))
        {
            return PotionsManager.badPotion;
        }
        return currentPotion;
    }

    public void Puntuation()
    {
        float newPuntuation = 5;
        if (!DictionaryExtensionMethods.ContentEquals(currentIngredients, usedIngredients))
        {
            if (IncorrectIngredients())
            {
                incorrectIngredients = true;
                newPuntuation -= 4;
            }
            else
            {
                incorrectQuantities = true;
                newPuntuation -= 1.5f;
            }
        }
        if (timeLeft < 0)
        {
            if (timeLeft <= -5)
            {
                slowTime3 = true;
                newPuntuation -= 2.5f;
            }
            else if (timeLeft <= -3)
            {
                slowTime2 = true;
                newPuntuation -= 1.5f;
            }
            else if (timeLeft <= -1)
            {
                slowTime1 = true;
                newPuntuation -= 0.5f;
            }
        }
        if (newPuntuation == 5)
            perfect = true;

        showExplanationDelegate?.Invoke(mistakes);
        showStarsDelegate?.Invoke(newPuntuation);
        puntuationsList.Add(newPuntuation);

        showMedianDelegate?.Invoke(Median(puntuationsList));

        usedIngredients.Clear();

        StartRecipe();
    }
}
public static class DictionaryExtensionMethods
{
    public static bool ContentEquals<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> otherDictionary)
    {
        return (otherDictionary ?? new Dictionary<TKey, TValue>())
            .OrderBy(kvp => kvp.Key)
            .SequenceEqual((dictionary ?? new Dictionary<TKey, TValue>())
                               .OrderBy(kvp => kvp.Key));
    }
}
