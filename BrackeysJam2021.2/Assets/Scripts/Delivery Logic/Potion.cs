using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potion : Catchable
{
    public string nameEffect;

    public delegate void DelegateSendPotion(string e);
    public static DelegateSendPotion delegateSendPotion;

    public void SetPotionEffect()
    {
        delegateSendPotion?.Invoke(nameEffect);
    }
}
