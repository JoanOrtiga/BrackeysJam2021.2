using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInvertEffect : PotionEffect
{
    private bool apply = false;

    public delegate void MouseInvertDelegate(bool valueInvert);
    public static MouseInvertDelegate DelegateMouseInvert;
    public override void ActivePotionEffect()
    {
        apply = true;
        DelegateMouseInvert?.Invoke(apply);
    }

    private void Update()
    {
        if (!apply)
            DelegateMouseInvert?.Invoke(false);
    }

    public override void StopPotionEffect()
    {
        apply = false;
    }
}
