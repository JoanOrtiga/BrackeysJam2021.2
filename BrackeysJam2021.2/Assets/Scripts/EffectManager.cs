using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static float timer = 0;
    private float maxTimer = 30;
    private bool startEffect;

    private PotionEffect currentPotionEffect;

    public delegate void DelegateEffectManager(bool desactive);
    public static DelegateEffectManager delegateEffectManager;

    private void OnEnable()
    {
        Potion.delegateSendPotion += SetPotionEffect;
    }

    private void OnDisable()
    {
        Potion.delegateSendPotion -= SetPotionEffect;
    }
    
    private void SetPotionEffect(string name)
    {
        currentPotionEffect = gameObject.GetComponent(name) as PotionEffect;
        Debug.Log(currentPotionEffect.GetType());

        if (currentPotionEffect is Fire)
        {
            startEffect = false;
        }
        else
            startEffect = true;


        currentPotionEffect.ActivePotionEffect();

    }

    private void StartClock()
    {
        
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            startEffect = false;
            timer = 0f;
            currentPotionEffect.StopPotionEffect();

        }
    }
    private void Update()
    {
        if (startEffect)
            StartClock();
        
    }

}
