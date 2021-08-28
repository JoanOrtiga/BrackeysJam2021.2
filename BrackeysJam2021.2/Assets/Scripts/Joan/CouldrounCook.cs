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

        public float maxCookTime;
        private float _currentCookTime;

        private bool _cooking = false;
        private void Update()
        {
            if(_cooking is false)
                return;
            
            _currentCookTime += Time.deltaTime;
            toolProgressUI.UpdateProgress(_currentCookTime/maxCookTime);
            
            if (_currentCookTime >= maxCookTime)
            {
                toolProgressUI.ShowStatus(false);
                SpawnPotion();
            }
        }

        private void SpawnPotion()
        {
            //Instantiate(potion, potionSpawnPoint.transform);
        }


        public void Interact()
        {
            if (couldronIngredients.IsEmpty() is false)
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

