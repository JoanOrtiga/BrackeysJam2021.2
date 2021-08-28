using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : Interactable
{
    [SerializeField]
    private Transform spawnerPoint;
    [SerializeField]
    private OrdersManager ordersManager;

    private float currentCooldown = 0;
    public float cooldown;
    private bool activate = false;
    GameObject potion;

    public delegate void StartCook();
    public static StartCook CookStart;

    public delegate void EndCook(string fx);
    public static EndCook CookEnd;
    public override void Active()
    {
        currentCooldown = cooldown;
        activate = true;
        potion = ordersManager.PotionDone();
        if (!(potion is null))
        {
            CookStart?.Invoke();
        }
    }
    private void Update()
    {
        if (activate)
        {
            if (!(potion is null))
            {
                currentCooldown -= Time.deltaTime;
                if (currentCooldown < 0)
                {
                    currentCooldown = cooldown;
                    activate = false;

                    Instantiate(potion, spawnerPoint.position, Quaternion.identity);
                    CookEnd?.Invoke(potion.GetComponent<Potion>().nameEffect);
                }
            }
            else
            {
                currentCooldown = cooldown;
                activate = false;
            }
        }

    }
}
