using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject customerRating;
    [SerializeField]
    private Transform verticalLayer;

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

    private void OnEnable()
    {
        OrdersManager.showExplanationDelegate += ShowExplanation;
    }
    private void OnDisable()
    {
        OrdersManager.showExplanationDelegate -= ShowExplanation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPanel();
        }
    }

    public void ShowPanel()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<CanvasGroup>().interactable = true;
        CameraController.CursorUnlock();
        Time.timeScale = 0f;
    }
    public void HidePanel()
    {
        GetComponent<Canvas>().enabled = false;
        GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1f;
        CameraController.CursorLock();
    }

    private void ShowExplanation(List<bool> mistakes, float stars, string customer)
    {
        var explanation = explanationGeneration(mistakes);
        var temp = Instantiate(customerRating, verticalLayer);
        temp.GetComponent<CustomerRating>().Generate(explanation, stars, customer);
    }
    private string explanationGeneration(List<bool> mistakes)
    {
        var explanation = "";

        for (int i = 0; i < mistakes.Count; i++)
        {
            if (mistakes[i])
                explanation += messages[i];
        }
        return explanation;
    }
}
