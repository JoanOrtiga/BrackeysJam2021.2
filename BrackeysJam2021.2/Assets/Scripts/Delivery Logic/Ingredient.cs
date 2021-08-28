using System.Collections;
using System.Collections.Generic;
using ChaosAlchemy;
using UnityEngine;

public class Ingredient : Catchable
{
    public IngredientType _ingredientType;
    public override string GetName()
    {
        return _ingredientType.ToString();
    }
}
