using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject fireParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Liquid")
        {
            FireOff();
            
        }
    }
    public void IsOnFire() //pa activar potion
    {
        fireParticle.SetActive(true);
        Interactable.isInteractable = false;
    }

    private void FireOff()
    {
        fireParticle.SetActive(false);
        Interactable.isInteractable = true;
    }
}
