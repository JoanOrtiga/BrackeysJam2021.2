using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public static bool isInteractable = true;

    private void OnEnable()
    {
        Fire.delegateFire += SetFire;
    }
    private void OnDisable()
    {
        Fire.delegateFire += SetFire;
    }
    
    
    
    private void SetFire(bool boolean)
    {
        foreach (Transform item in GetComponentsInChildren<Transform>(true))
        {
            if(item.tag == "FireParticle")
            {
                item.gameObject.SetActive(boolean);
                print("Es aqui");
                //return;
            }
        }
    }

    public void Interact()
    {
        if(isInteractable)
        {
            Active();
        }
    }
    public abstract void Active();
}
