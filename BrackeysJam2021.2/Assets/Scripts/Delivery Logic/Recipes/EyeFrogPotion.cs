using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFrogPotion : IRecipe
{
    public Dictionary<string, int> Ingredients => new Dictionary<string, int> {
            {"Eye", 3},
            {"Frog", 2},
            };
    public string Name => "EyeFrogPotion";
    public string Description => "To do something";
    public float DefaultTime => 6f;
}
