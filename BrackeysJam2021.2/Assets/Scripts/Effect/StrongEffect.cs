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
    public static StrongDelegate DelegatStrong;

    private void OnEnable()
    {
        EffectManager.delegateEffectManager += GetApplyValue;
    }

    private void OnDisable()
    {
        EffectManager.delegateEffectManager -= GetApplyValue;
    }

    private void GetApplyValue(bool value)
    {
        apply = value;
    }

    public override void ActivePotionEffect()
    {
        apply = (bool)delegateClock?.Invoke();
        ApplyStrongEffect();
    }

    private void ApplyStrongEffect()
    {
        DelegatStrong?.Invoke(StrongValueEffect);
    }
    private void Update()
    {
        if (!apply)
            DelegatStrong?.Invoke(defaultValue);
    }
}
