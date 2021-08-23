using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    public delegate void OnRecipeStartDelegate(IRecipe recipe);
    public static OnRecipeStartDelegate recipeStartDelegate;
    public delegate void OnTimeLeftDelegate(float timeLeftPercentage);
    public static OnTimeLeftDelegate timeLeftDelegate;

    private List<IRecipe> recipesList;
    private float recipeTime;
    private float timeLeft;

    private void Start()
    {
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
        if (timeLeft < 0)
        {
            StartRecipe();
        }
        timeLeft -= Time.deltaTime;
        timeLeftDelegate?.Invoke(timeLeft/recipeTime);
    }

    private IRecipe GetRandomRecipe()
    {
        IRecipe recipe;

        recipe = recipesList[UnityEngine.Random.Range(0, recipesList.Count)];

        return recipe;
    }

    private void StartRecipe()
    {
        var recipe = GetRandomRecipe();
        recipeTime = recipe.DefaultTime;
        timeLeft = recipeTime;
        recipeStartDelegate?.Invoke(recipe);
    }
}
