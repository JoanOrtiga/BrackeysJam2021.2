using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomerRating : MonoBehaviour
{
    [SerializeField]
    private GameObject stars;
    [SerializeField]
    private TextMeshProUGUI explanationText;
    [SerializeField]
    private TextMeshProUGUI customerText;

    public void Generate(string explanation, float stars, string customer)
    {
        explanationText.text = explanation;
        customerText.text = customer;
        ShowStars(stars);
        Debug.Log("explanation");
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
}
