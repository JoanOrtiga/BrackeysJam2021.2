using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ChaosAlchemy
{
    public class RecipePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshPro customerName;
        [SerializeField] private TextMeshPro potionName;
        [SerializeField] private TextMeshPro recipeIngredients;

        [SerializeField] private float timeBetweenCharacters = 0.01f;

        [SerializeField] private VoiceTranslator voiceTranslator;

        public IEnumerator NewRecipe(string CustomerName, string PotionName, List<IngredientType> ingredients)
        {
            
            potionName.text = String.Empty;
            recipeIngredients.text = String.Empty;
            
            string totalIngredients = String.Empty;
            foreach (var ingredient in ingredients)
            {
                totalIngredients += ingredient.ToString() + "\n";
            }
            
            voiceTranslator.Translator(PotionName + totalIngredients);
            
            customerName.text = CustomerName;
            
            for (int i = 0; i < PotionName.Length; i++)
            {
                potionName.text += PotionName[i];
                yield return new WaitForSeconds(timeBetweenCharacters);
            }
            
            for (int i = 0; i < totalIngredients.Length; i++)
            {
                recipeIngredients.text += totalIngredients[i];
                yield return new WaitForSeconds(timeBetweenCharacters);
            }
        }
    }

}
