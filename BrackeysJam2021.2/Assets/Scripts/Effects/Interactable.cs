using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public static bool isInteractable = true;
    public void Interact()
    {
        if(isInteractable)
        {
            Active();
        }
    }
    public abstract void Active();
}
