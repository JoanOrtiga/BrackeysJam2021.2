using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPoint : MonoBehaviour
{
    [SerializeField] private float timeUntilDissapear;
    
    [SerializeField]
    private OrdersManager ordersManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            StartCoroutine(TimeUntilDissapear(other.gameObject));
        }
       

        /*
        if ((other.GetComponent("Potion") as Potion) != null)
        {
            Destroy(other);
            ordersManager.Puntuation();
        }
        */
    }

    IEnumerator TimeUntilDissapear(GameObject potion)
    {
        yield return new WaitForSeconds(timeUntilDissapear);
        
        Destroy(potion);
    }
    
}
