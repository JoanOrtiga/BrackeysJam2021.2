using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Interactable
{
    [SerializeField]
    private Transform spawnerPoint;
    [SerializeField]
    private OrdersManager ordersManager;
    public override void Active()
    {
        Instantiate(ordersManager.PotionDone(), spawnerPoint.position, Quaternion.identity);
    }
}
