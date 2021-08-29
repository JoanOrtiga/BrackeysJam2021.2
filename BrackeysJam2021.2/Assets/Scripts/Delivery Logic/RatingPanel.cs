using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingPanel : MonoBehaviour
{
    [SerializeField]
    private CustomerRating customerRating;

    [Header("Ratings explanation")]
    [SerializeField]
    private string incorrectIngredients;
    [SerializeField]
    private string slow;
    [SerializeField]
    private string noTime;
    [SerializeField]
    private string perfect;
    private List<string> messages => new List<string> { incorrectIngredients, slow, noTime, perfect };

    
    private CanvasGroup _canvasGroup;
    
    
    private bool shown = false;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        OrdersManager.showExplanationDelegate += ShowExplanation;
    }
    private void OnDisable()
    {
        OrdersManager.showExplanationDelegate -= ShowExplanation;
    }

    public void ShowPanel()
    {
        _canvasGroup.interactable = true;
        _canvasGroup.alpha = 1.0f;
        _canvasGroup.blocksRaycasts = true; 
        PlayerController.CursorUnlock();
        Time.timeScale = 0f;
        shown = true;
    }
    public void HidePanel()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.alpha = 0.0f;
        _canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1f;
        PlayerController.CursorLock();
        shown = false;
    }

    public void ShowExplanation(List<bool> mistakes, float stars, string customer)
    {
        var explanation = ExplanationGeneration(mistakes);
        customerRating.Generate(explanation, stars, customer);
        ShowPanel();
    }
    private string ExplanationGeneration(List<bool> mistakes)
    {
        var explanation = "";

        for (int i = 0; i < mistakes.Count; i++)
        {
            if (mistakes[i])
            {
                explanation += messages[i];
            }
        }
        return explanation;
    }
}
