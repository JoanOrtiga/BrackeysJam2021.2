using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInvertEffect : PotionEffect
{
    private bool apply = false;

    public delegate void MouseInvertDelegate(bool valueInvert);
    public static MouseInvertDelegate DelegateMouseInvert;

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
        DelegateMouseInvert?.Invoke(apply);
    }

    private void Update()
    {
        if (!apply)
            DelegateMouseInvert?.Invoke(false);
    }
}
