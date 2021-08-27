using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecipe
{
    public Dictionary<string, int> Ingredients { get; }
    public string Potion { get; }
    public string Description { get; }
    public float DefaultTime { get; } //without difficulty incrementation
}
