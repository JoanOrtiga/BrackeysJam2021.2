using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static float timer = 0;
    private float maxTimer = 5;
    private bool startEffect;

    public delegate void DelegateEffectManager(bool desactive);
    public static DelegateEffectManager delegateEffectManager;

    private void OnEnable()
    {
        PotionEffect.delegateClock += EffectEnter;
    }
    private void OnDisable()
    {
        PotionEffect.delegateClock -= EffectEnter;
    }
    private bool EffectEnter()
    {
        return startEffect = true;
    }

    private void StartClock()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            startEffect = false;
            timer = 0f;
            delegateEffectManager?.Invoke(false);
        }
        print(timer);
    }
    private void Update()
    {
        if (startEffect)
            StartClock();
    }

}
