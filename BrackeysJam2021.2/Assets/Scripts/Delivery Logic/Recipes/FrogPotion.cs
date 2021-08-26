using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPotion : IRecipe
{
    public Dictionary<string, int> Ingredients => new Dictionary<string, int> {
            {"Frog", 4},
            {"Essence", 1},
            };
    public string Potion => "FrogPotion";
    public string Description => "To be ugly";
    public float DefaultTime => 40f;
}
