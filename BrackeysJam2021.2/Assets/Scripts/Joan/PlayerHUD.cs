using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Image timeLeft;
    [SerializeField] private TextMeshProUGUI objectOnHand;
    [SerializeField] private GameObject starsParent;
    private Image[] _stars;

    private void Awake()
    {
        _stars = starsParent.GetComponentsInChildren<Image>();
    }

    public void UpdateTimeLeft(float timeLeftPercentage)
    {
        timeLeft.fillAmount = timeLeftPercentage;
    }

    public void UpdateObjectOnHand(string itemOnHand)
    {
        objectOnHand.text = itemOnHand;
    }
    
    public void StarsAverage(List<float> puntuations)
    {
        float sum = 0;
        foreach (var value in puntuations)
        {
            sum += value;
        }

        sum /= puntuations.Count;
        
        
        foreach (Image star in _stars)
        {
            if (sum >= 0.5)
            {
                star.enabled = true;
                sum -= 0.5f;
            }
            else
                star.enabled = false;
        }
    }
}
