using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Catchable>() != null)
            Destroy(other.gameObject, 0.2f);
    }
}
