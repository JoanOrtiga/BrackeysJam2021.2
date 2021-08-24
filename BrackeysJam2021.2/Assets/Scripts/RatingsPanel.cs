using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RatingsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject stars;
    [SerializeField]
    private TextMeshProUGUI explanationText;

    [Header("Ratings explanation")]
    [SerializeField]
    private string perfect;
    [SerializeField]
    private string incorrectIngredients;
    [SerializeField]
    private string incorrectQuantities;
    [SerializeField]
    private string slowTime1;
    [SerializeField]
    private string slowTime2;
    [SerializeField]
    private string slowTime3;

    private string explanation;

    private void OnEnable()
    {
        RecipesManager.incorrectIngredientsDelegate += addExplanation1;
        RecipesManager.incorrectQuantitiesDelegate += addExplanation2;
        RecipesManager.slowTime1Delegate += addExplanation3;
        RecipesManager.slowTime2Delegate += addExplanation4;
        RecipesManager.slowTime3Delegate += addExplanation5;
        RecipesManager.perfectDelegate += addExplanation6;
        RecipesManager.showExplanationDelegate += ShowExplanation;
        RecipesManager.showStarsDelegate += ShowStars;
    }
    private void OnDisable()
    {
        RecipesManager.incorrectIngredientsDelegate -= addExplanation1;
        RecipesManager.incorrectQuantitiesDelegate -= addExplanation2;
        RecipesManager.slowTime1Delegate -= addExplanation3;
        RecipesManager.slowTime2Delegate -= addExplanation4;
        RecipesManager.slowTime3Delegate -= addExplanation5;
        RecipesManager.perfectDelegate -= addExplanation6;
        RecipesManager.showExplanationDelegate -= ShowExplanation;
        RecipesManager.showStarsDelegate -= ShowStars;
    }

    private void Start()
    {
        explanation = "";
    }
    private void ShowStars (float puntuation)
    {
        foreach(Image star in stars.GetComponentsInChildren<Image>())
        {
            if (puntuation >= 0.5)
            {
                star.enabled = true;
                puntuation -= 0.5f;
            }
            else
                return;
        }
    }

    public void HidePanel()
    {
        foreach (Image star in stars.GetComponentsInChildren<Image>())
        {
            star.enabled = false;
        }
        GetComponent<Canvas>().enabled = false;
    }

    private void ShowExplanation()
    {
        explanationText.text = explanation;
        explanation = "";
        GetComponent<Canvas>().enabled = true;
    }

    private void addExplanation1()
    {
        explanation += incorrectIngredients + " ";
    }
    private void addExplanation2()
    {
        explanation += incorrectQuantities + " ";
    }
    private void addExplanation3()
    {
        explanation += slowTime1 + " ";
    }
    private void addExplanation4()
    {
        explanation += slowTime2 + " ";
    }
    private void addExplanation5()
    {
        explanation += slowTime3 + " ";
    }
    private void addExplanation6()
    {
        explanation += perfect + " ";
    }
}
