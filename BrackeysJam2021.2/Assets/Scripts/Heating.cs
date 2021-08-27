using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heating : MonoBehaviour
{
    public Converter Converter;

    public float timeHeated;

    private float heatTime = 3f;

    private bool alreadyHeated;

    private void Update()
    {
        if (heatTime <= timeHeated && !alreadyHeated)
        {
            alreadyHeated = true;
            Heated();
            timeHeated = 0;
        }
    }

    private void Heated()
    {
        Converter.CovertIngredient(GetComponent<Ingredient>());
    }
}
