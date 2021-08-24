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

    public delegate void OnIncorrectIngredientsDelegate();
    public static OnIncorrectIngredientsDelegate incorrectIngredientsDelegate;
    public delegate void OnIncorrectQuantitiesDelegate();
    public static OnIncorrectQuantitiesDelegate incorrectQuantitiesDelegate;
    public delegate void OnSlowTime1Delegate();
    public static OnSlowTime1Delegate slowTime1Delegate;
    public delegate void OnSlowTime2Delegate();
    public static OnSlowTime2Delegate slowTime2Delegate;
    public delegate void OnSlowTime3Delegate();
    public static OnSlowTime3Delegate slowTime3Delegate;
    public delegate void OnPerfectDelegate();
    public static OnPerfectDelegate perfectDelegate;
    public delegate void OnShowExplanationDelegate();
    public static OnShowExplanationDelegate showExplanationDelegate;
    public delegate void OnShowStarsDelegate(float puntuation);
    public static OnShowStarsDelegate showStarsDelegate;

    public delegate void OnShowMedianDelegate(float puntuation);
    public static OnShowMedianDelegate showMedianDelegate;

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

        StartRecipe();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float newPuntuation = 5;
            if (!DictionaryExtensionMethods.ContentEquals(currentIngredients, usedIngredients))
            {
                if (IncorrectIngredients())
                {
                    incorrectIngredientsDelegate?.Invoke();
                    newPuntuation -= 4;
                }
                else
                {
                    incorrectQuantitiesDelegate?.Invoke();
                    newPuntuation -= 1.5f;
                }
            }
            if (timeLeft < 0)
            {
                if (timeLeft <= -5)
                {
                    slowTime3Delegate?.Invoke();
                    newPuntuation -= 2.5f;
                }
                else if (timeLeft <= -3)
                {
                    slowTime2Delegate?.Invoke();
                    newPuntuation -= 1.5f;
                }
                else if (timeLeft <= -1)
                {
                    slowTime1Delegate?.Invoke();
                    newPuntuation -= 0.5f;
                }
            }
            if (newPuntuation == 5)
                perfectDelegate?.Invoke();

            showExplanationDelegate?.Invoke();
            showStarsDelegate?.Invoke(newPuntuation);
            puntuationsList.Add(newPuntuation);

            showMedianDelegate?.Invoke(Median(puntuationsList));

            usedIngredients.Clear();
        }

        timeLeft -= Time.deltaTime;
        timeLeftDelegate?.Invoke(timeLeft/ currentDefaultTime);
    }

    private float Median(List<float> putuationsList)
    {
        float sum = 0;
        foreach(int num in puntuationsList)
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

    private IRecipe GetRandomRecipe()
    {
        IRecipe recipe;

        recipe = recipesList[UnityEngine.Random.Range(0, recipesList.Count)];

        return recipe;
    }

    public void StartRecipe()
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

