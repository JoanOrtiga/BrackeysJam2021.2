using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] FX;

    private void OnEnable()
    {
        Cook.CookEnd += OnCookEnd;
    }

    private void OnDisable()
    {
        Cook.CookEnd -= OnCookEnd;
    }

    private void OnCookEnd(String name)
    {
        
    }
}
