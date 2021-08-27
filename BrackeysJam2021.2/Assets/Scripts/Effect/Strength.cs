using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEffect : PotionEffect
{
    [SerializeField]
    private float StrongValueEffect = 15f;
    private float defaultValue = 1f;
    private bool apply = false;

    public delegate void StrongDelegate(float newValue);
    public static StrongDelegate delegateStrong;

    public override void ActivePotionEffect()
    {
        apply = true;
        ApplyStrongEffect();
    }

    private void ApplyStrongEffect()
    {
        delegateStrong?.Invoke(StrongValueEffect);
    }
    private void Update()
    {
        if (!apply)
            delegateStrong?.Invoke(defaultValue);
    }

    public override void StopPotionEffect()
    {
        apply = false;
    }
}
