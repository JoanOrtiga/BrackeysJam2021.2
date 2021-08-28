using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosAlchemy
{
    public class CouldrounIngredients : MonoBehaviour
    {
        private GameController _gameController;

        private bool oneIngredientOrMore = false;
        
        private void Awake()
        {
            _gameController = FindObjectOfType<GameController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Interesting"))
            {
                oneIngredientOrMore = true;
                _gameController.UpdateCurrentRecipe(other.GetComponent<Ingredient>()._ingredientType);
                Destroy(other.gameObject, 0.1f);
            }
        }

        public bool IsEmpty()
        {
            return !oneIngredientOrMore;
        }
        
        public void ResetCouldroun()
        {
            oneIngredientOrMore = false;
        }
    }
}

