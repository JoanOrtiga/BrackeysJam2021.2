using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : CaosEffect
{
    public delegate void FireDelegate(bool boolean);
    public static FireDelegate delegateFire;

   
    public override void ActiveEffectCaos()
    {
        IsOnFire();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Liquid")
        {
            FireOff();
        }

    }
    public void IsOnFire() //FUNCIÓN PARA ACTIVAR EL FUEGO.
    {
        delegateFire?.Invoke(true);
        Interactable.isInteractable = false;
    }

    private void FireOff()
    {
        delegateFire?.Invoke(false);
        Interactable.isInteractable = true;
    }
    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Y))
        {
            IsOnFire();
            print("y");
        }

    }

}
