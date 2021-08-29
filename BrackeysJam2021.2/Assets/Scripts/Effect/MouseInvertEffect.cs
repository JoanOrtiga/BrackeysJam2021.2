using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInvertEffect : PotionEffect
{
    private bool apply = false;

    public delegate void MouseInvertDelegate(bool valueInvert);
    public static MouseInvertDelegate DelegateMouseInvert;
    public ParticleSystem Particles;
    public override void ActivePotionEffect()
    {
        Particles.gameObject.SetActive(true);
        apply = true;
        Particles.Play();
        DelegateMouseInvert?.Invoke(apply);
    }

    private void Update()
    {
        if (!apply)
            DelegateMouseInvert?.Invoke(false);
    }

    public override void StopPotionEffect()
    {
        Particles.gameObject.SetActive(false);
        apply = false;
    }
}
