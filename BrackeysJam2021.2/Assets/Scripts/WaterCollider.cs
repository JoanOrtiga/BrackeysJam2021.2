using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{
    public delegate void DelegateWaterCollider();
    public static DelegateWaterCollider delegateWaterCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Liquid")
        {
            print("en el tringerr ttoy");
            delegateWaterCollider?.Invoke();
        }
    }
}
