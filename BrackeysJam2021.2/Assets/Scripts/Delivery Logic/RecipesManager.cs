using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    private void OnEnable()
    {
        IngredientsChecker.ingredientUsedDelegate += IngredientUsed;
    }
    private void OnDisable()
    {
        IngredientsChecker.ingredientUsedDelegate -= IngredientUsed;
    }

    public delegate void OnRecipeStartDelegate(IRecipe recipe);
    public static OnRecipeStartDelegate recipeStartDelegate;
    public delegate void OnTimeLeftDelegate(float timeLeftPercentage);
    public static OnTimeLeftDelegate timeLeftDelegate;

    private List<IRecipe> recipesList;

    private IRecipe currentRecipe;
    private Dictionary<string, int> currentIngredients => currentRecipe.Ingredients;
    private float currentDefaultTime => currentRecipe.DefaultTime;

    private Dictionary<string, int> usedIngredients;
    private float timeLeft;

    //Puntuation
    List<float> puntuationsList;

    private void Start()
    {
        usedIngredients = new Dictionary<string, int>();
        puntuationsList = new List<float>();

        var list = Assembly.GetAssembly(typeof(IRecipe)).GetTypes()
            .Where(x => !x.IsInterface && typeof(IRecipe).IsAssignableFrom(x));

        recipesList = new List<IRecipe>();

        foreach (var type in list)
        {
            var tempRecipe = Activator.CreateInstance(type);
            recipesList.Add((IRecipe)tempRecipe);
        }

        foreach(var recipe in recipesList)
        {
            Debug.Log(recipe.Name);
        }

        StartRecipe();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float newPuntuation = 5;
            if (!DictionaryExtensionMethods.ContentEquals(currentIngredients, usedIngredients))
            {
                if (IncorrectIngredients())
                {
                    newPuntuation -= 4;
                }
                else
                {
                    newPuntuation -= 1;
                }
            }
            if (timeLeft < 0)
            {
                if (timeLeft <= -6)
                    newPuntuation -= 3;
                else if (timeLeft <= -4)
                    newPuntuation -= 2;
                else if (timeLeft <= -2)
                    newPuntuation -= 1;
            }
            puntuationsList.Add(newPuntuation);
            Debug.Log("Putuation: " + newPuntuation);
            Debug.Log("Median: " + Median(puntuationsList));
            usedIngredients.Clear();
            StartRecipe();
        }

        timeLeft -= Time.deltaTime;
        timeLeftDelegate?.Invoke(timeLeft/ currentDefaultTime);
    }

    private float Median(List<float> putuationsList)
    {
        float sum = 0;
        foreach(int num in puntuationsList)
            sum += num;

        return sum / (float)puntuationsList.Count;
    }

    private bool IncorrectIngredients()
    {
        foreach (KeyValuePair<string, int> entry in usedIngredients)
        {
            int value = 0;
            if (!currentIngredients.TryGetValue(entry.Key, out value))
                return true;
        }
        return false;
    }

    private IRecipe GetRandomRecipe()
    {
        IRecipe recipe;

        recipe = recipesList[UnityEngine.Random.Range(0, recipesList.Count)];

        return recipe;
    }

    private void StartRecipe()
    {
        currentRecipe = GetRandomRecipe();
        timeLeft = currentDefaultTime;
        recipeStartDelegate?.Invoke(currentRecipe);
    }

    private void IngredientUsed(string name)
    {
        int value = 0;
        if(usedIngredients.TryGetValue(name, out value))
        {
            value++;
            usedIngredients[name] = value;
        }
        else
        {
            usedIngredients.Add(name, 1);
        }
        printIngredients();
    }

    private void printIngredients()
    {
        string ingredients = "";
        foreach (KeyValuePair<string, int> entry in usedIngredients)
        {
            ingredients += entry.Key + " x" + entry.Value.ToString() + " / ";
        }
        Debug.Log(ingredients);
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

