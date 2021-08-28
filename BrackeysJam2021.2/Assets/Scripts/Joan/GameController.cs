using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosAlchemy
{
    public class GameController : MonoBehaviour
    {
        private Recipe _currentRecipe;
        private string _currentCustomerName;
        private int _recipeErrors = 0;

        public Recipes recipes;
        public CustomerNames customerNames;

        [Header("Puntuation")] 
        public float maxScore = 5f;
        private float _currentScore;
        
        
        [Header("Settings")] 
        public float maxRecipeTime;
        private float _currentRecipeTime;

        
        private RatingPanel _ratingPanel;
        private RecipePanel _recipePanel;
        private PlayerHUD _playerHUD;

        private List<float> _allScores = new List<float>();


        private bool starQuarterTime = false;

        private bool incorrectIngredients;
        private bool slow;
        private bool noTime;
        private bool perfect;
        private List<bool> mistakes => new List<bool> { incorrectIngredients, slow, noTime, perfect };

        private int counter;

        private void Awake()
        {
            _ratingPanel = FindObjectOfType<RatingPanel>();
            _recipePanel = FindObjectOfType<ChaosAlchemy.RecipePanel>();
            _playerHUD = FindObjectOfType<PlayerHUD>();

            counter = 0;
            GetNewRecipeByIndex(counter);
            counter++;
            _currentRecipeTime = maxRecipeTime;
        }

        private void Update()
        {
            _currentRecipeTime -= Time.deltaTime;
            _playerHUD.UpdateTimeLeft(_currentRecipeTime / maxRecipeTime);

            if (_currentRecipeTime <= 0)
            {
                UpdateScore(0.0f);
                slow = false;
                noTime = true;
                EndRecipe();
            }

            if (!starQuarterTime && _currentRecipeTime <= maxRecipeTime / 4)
            {
                starQuarterTime = true;
                slow = true;
                UpdateScore(_currentScore - 1.0f);
            }
        }

        //Add ingredients to the recipe (in cauldron)
        public void UpdateCurrentRecipe(IngredientType ingredient)
        {
            for (int i = 0; i < _currentRecipe.ingredients.Count; i++)
            {
                if (_currentRecipe.ingredients[i] == ingredient)
                {
                    _currentRecipe.ingredients.RemoveAt(i);
                    return;
                }
            }

            _recipeErrors++;
            if (_recipeErrors >= _currentRecipe.ingredients.Count/2)
            {
                UpdateScore(_currentScore - 1.0f);
                incorrectIngredients = true;
            }
        }
        
        public void UpdateScore(float score)
        {
            _currentScore = score;
            //ShowScore on sigui
        }
        
        public void EndRecipe()
        {
            if (_currentScore == maxScore)
            {
                perfect = true;
            }
            _allScores.Add(_currentScore);
            _playerHUD.StarsAverage(_allScores);
            _ratingPanel.ShowExplanation(mistakes, _currentScore, _currentCustomerName);
            GetNewRecipe();
            ResetMistakes();
            if (counter < 3)
            {
                GetNewRecipeByIndex(counter);
                counter++;
            }
        }

        public void GetNewRecipeByIndex(int id)
        {
            _currentRecipe = recipes.GetRecipeByIndex(id);
            _currentScore = maxScore;
            _currentRecipeTime = maxRecipeTime;
            _currentCustomerName = customerNames.GetRandomCustomerName();
            _recipePanel.StopAllCoroutines();
            _recipePanel.StartCoroutine(_recipePanel.NewRecipe(_currentCustomerName, _currentRecipe.name, _currentRecipe.ingredients));
            _recipeErrors = 0;
            starQuarterTime = false;
        }

        public void GetNewRecipe()
        {
            _currentRecipe = recipes.GetRandomRecipe();
            _currentRecipeTime = maxRecipeTime;
            _currentScore = maxScore;
            _currentCustomerName = customerNames.GetRandomCustomerName();
            _recipePanel.StopAllCoroutines();
            _recipePanel.StartCoroutine(_recipePanel.NewRecipe(_currentCustomerName, _currentRecipe.name, _currentRecipe.ingredients));
            _recipeErrors = 0;
            starQuarterTime = false;
        }
        
        //GetPotionType from cauldron.
        public GameObject PotionDone()
        {
            if (_currentRecipe.ingredients.Count > 0)
            {
                return recipes.badPotion;
            }
            
            return _currentRecipe.potion;

            /*
            if (usedIngredients.Count > 0)
            {
                if (!DictionaryExtensionMethods.ContentEquals(currentIngredients, usedIngredients))
                {
                    return PotionsManager.badPotion;
                } else
                {
                    currentPotion.GetComponent<PotionEffect>().ActivePotionEffect();
                    return currentPotion;
                }
            }
            */
        }
        private void ResetMistakes()
        {
            incorrectIngredients = false;
            slow = false;
            noTime = false;
            perfect = false;
        }
    }
}

