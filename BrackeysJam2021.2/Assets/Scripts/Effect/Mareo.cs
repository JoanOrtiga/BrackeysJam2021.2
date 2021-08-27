using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mareo : PotionEffect
{
    private GameObject distorsion;
    private bool apply = false;

    public delegate GameObject DistorsionDelegate();
    public static DistorsionDelegate distorsionDelegate;

    
    public delegate void Delegatee(bool state);
    public static Delegatee delegatee;
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
        print("GET APPLY VALUE");
        apply = value;
    }

    private void Awake()
    {
        distorsion = distorsionDelegate?.Invoke();
        
        distorsion.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!apply)
        {
            ChangeToNormal();
        }
    }

    private void ChangeToDistorsion()
    {
        distorsion.gameObject.SetActive(true);
    }

    private void ChangeToNormal()
    {
        distorsion.gameObject.SetActive(false);
    }

    public override void ActivePotionEffect()
    {

        apply = (bool)delegateClock?.Invoke();

        ChangeToDistorsion();
    }
}
