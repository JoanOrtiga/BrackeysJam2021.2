using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    private static List<IRecipe> recipesList;

    private static IRecipe recipe;

    public static IRecipe Recipe { get { return recipe; } }

    private void Awake()
    {
        recipesList = new List<IRecipe>();
        GetProjectRecipe();
        SetRandomRecipe();
    }

    private void GetProjectRecipe()
    {
        var listCustomers = Assembly.GetAssembly(typeof(IRecipe)).GetTypes()
            .Where(x => !x.IsInterface && typeof(IRecipe).IsAssignableFrom(x));

        foreach (var type in listCustomers)
        {
            var tempCustomer = Activator.CreateInstance(type);
            recipesList.Add((IRecipe)tempCustomer);
        }
    }

    public static void SetRandomRecipe()
    {
        recipe = recipesList[UnityEngine.Random.Range(0, recipesList.Count)];
    }
}

