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
        var potion = ordersManager.PotionDone();
        if (!(potion is null))
        {
            Instantiate(potion, spawnerPoint.position, Quaternion.identity);
        }
    }
}
