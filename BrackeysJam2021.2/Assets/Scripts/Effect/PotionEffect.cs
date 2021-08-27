using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionEffect : MonoBehaviour
{
    public abstract void ActivePotionEffect();

    public delegate bool DelegateClock();
    public static DelegateClock delegateClock;
}
