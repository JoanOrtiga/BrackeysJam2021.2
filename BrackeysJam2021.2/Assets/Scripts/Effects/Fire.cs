using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool fire = false;
    public GameObject fireParticle;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Liquid")
        {
            FireOff();
        }
    }

    private void IsOnFire()
    {
        fireParticle.SetActive(true);
        fire = true;
    }

    private void FireOff()
    {
        fireParticle.SetActive(false);
        fire = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            IsOnFire();
        }
    }
}
