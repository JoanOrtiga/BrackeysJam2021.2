using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsMedian : MonoBehaviour
{
    private void OnEnable()
    {
        OrdersManager.showMedianDelegate += ShowStars;
    }
    private void OnDisable()
    {
        OrdersManager.showMedianDelegate -= ShowStars;
    }
    private void ShowStars(float puntuation)
    {
        foreach (Image star in GetComponentsInChildren<Image>())
        {
            if (puntuation >= 0.5)
            {
                star.enabled = true;
                puntuation -= 0.5f;
            }
            else
                star.enabled = false;
        }
    }
}
