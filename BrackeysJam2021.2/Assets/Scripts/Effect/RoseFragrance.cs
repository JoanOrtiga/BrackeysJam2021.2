using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseFragrance : PotionEffect
{
    private bool apply = false;

    public delegate void RoseFragrandeDelegate(bool state);
    public static RoseFragrandeDelegate delegateRoseFragrance;

    public ParticleSystem Particles;


    public override void ActivePotionEffect()
    {
        Particles.gameObject.SetActive(true);
        Particles.Play();
        apply = true;
        ApplyRoseFraganceEffect();
    }

    private void ApplyRoseFraganceEffect()
    {
        delegateRoseFragrance?.Invoke(true);
    }
    private void Update()
    {
        if (!apply)
            delegateRoseFragrance?.Invoke(false);
    }
    public override void StopPotionEffect()
    {
        Particles.gameObject.SetActive(false);
        apply = false;
    }
}
