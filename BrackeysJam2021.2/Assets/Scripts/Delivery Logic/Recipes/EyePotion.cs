using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePotion : IRecipe
{
    public Dictionary<string, int> Ingredients => new Dictionary<string, int> {
            {"Eye", 3},
            {"Essence", 2},
            };
    public string Name => "EyePotion";
    public string Description => "To have better sight";
    public float DefaultTime => 3f;
}
