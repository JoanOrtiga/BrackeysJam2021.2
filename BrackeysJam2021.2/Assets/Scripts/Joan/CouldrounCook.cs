using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosAlchemy
{
    public class CouldrounCook : MonoBehaviour , IInteractable
    {
        [SerializeField] private CouldrounIngredients couldronIngredients;

        [SerializeField] private Transform potionSpawnPoint;
        
        [SerializeField] private ToolProgressUI toolProgressUI;

        private GameController _gameController;
        
        public float maxCookTime;
        private float _currentCookTime;

        private bool _cooking = false;

        private void Awake()
        {
            _gameController = FindObjectOfType<GameController>();
        }

        private void Update()
        {
            if(_cooking is false)
                return;
            
            _currentCookTime += Time.deltaTime;
            toolProgressUI.UpdateProgress(_currentCookTime/maxCookTime);
            
            if (_currentCookTime >= maxCookTime)
            {
                couldronIngredients.ResetCouldroun();
                toolProgressUI.ShowStatus(false);
                _cooking = false;
                SpawnPotion();
            }
        }

        private void SpawnPotion()
        {
            var potion = _gameController.PotionDone();
            if (!(potion is null))
            {
                GameObject spawnerPotion = Instantiate(potion, potionSpawnPoint.position, Quaternion.identity);
                spawnerPotion.GetComponent<PotionEffect>()?.ActivePotionEffect();
            }
            else
            {
                Debug.Log("Shouldn't be null");
            }
        }


        public void Interact()
        {
            if (couldronIngredients.IsEmpty() is false && _cooking is false)
            {
                StartCooking();
            }
        }

        private void StartCooking()
        {
            toolProgressUI.ShowStatus(true);
            _cooking = true;
            _currentCookTime = 0;
        }
    }
}

