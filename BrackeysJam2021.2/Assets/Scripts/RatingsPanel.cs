using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RatingsPanel : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.GameObject stars;
    [SerializeField]
    private TextMeshProUGUI explanationText;

    [Header("Ratings explanation")]
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
    [SerializeField]
    private string perfect;
    private List<string> messages => new List<string> { incorrectIngredients, incorrectQuantities, slowTime1, slowTime2, slowTime3, perfect };

    private string explanation;

    private void OnEnable()
    {
        OrdersManager.showExplanationDelegate += ShowExplanation;
        OrdersManager.showStarsDelegate += ShowStars;
    }
    private void OnDisable()
    {
        OrdersManager.showExplanationDelegate -= ShowExplanation;
        OrdersManager.showStarsDelegate -= ShowStars;
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
        GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1f;
        CameraController.CursorLock();
    }

    private void ShowExplanation(List<bool> mistakes)
    {
        explanationGeneration(mistakes);
        explanationText.text = explanation;
        explanation = "";
        GetComponent<Canvas>().enabled = true;
        GetComponent<CanvasGroup>().interactable = true;
        CameraController.CursorUnlock();
        Time.timeScale = 0f;
    }

    private void explanationGeneration(List<bool> mistakes)
    {
        for(int i=0; i < mistakes.Count; i++)
        {
            if (mistakes[i])
                explanation += messages[i];
        }
    }
}
