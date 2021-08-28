using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ChaosAlchemy
{
    [CreateAssetMenu(fileName = "Recipes", menuName = "Recipes", order = 1)]
    public class Recipes : ScriptableObject
    {
        public List<Recipe> recipes = new List<Recipe>();

        public Recipe GetRandomRecipe()
        {
            return recipes[Random.Range(0, recipes.Count)];
        }

        public Recipe GetRecipeByIndex(int id)
        {
            return recipes[id];
        }
    }
    
    [Serializable]
    public struct Recipe
    {
        public string name;
        public List<IngredientType> ingredients;
    }

    public enum IngredientType
    {
        Kerosene = 0,
        BatTears, 
        Wine, 
        Water, 
        Alstroemeria, 
        PsilocybeCubensis, 
        PotassiumNitrate, 
        LizardEye, 
        UnicornHorn, 
        LepiotaBrunneoincarnata
    }
}
