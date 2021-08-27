using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPoint : MonoBehaviour
{
    [SerializeField]
    private OrdersManager ordersManager;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponent("Potion") as Potion) != null)
        {
            Destroy(other);
            ordersManager.Puntuation();
        }
    }
}
