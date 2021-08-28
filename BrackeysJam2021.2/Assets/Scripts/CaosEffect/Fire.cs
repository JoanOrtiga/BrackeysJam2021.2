using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : PotionEffect
{
    public delegate void FireDelegate(bool boolean);
    public static FireDelegate delegateFire;

    //[SerializeField]
    public GameObject WaterColliderGameObject;

    public ParticleSystem Particles;
    private void OnEnable()
    {
        WaterCollider.delegateWaterCollider += FireOff;
    }

    private void OnDisable()
    {
        WaterCollider.delegateWaterCollider -= FireOff;
    }
    public void IsOnFire()
    {
        WaterColliderGameObject.SetActive(true);
        delegateFire?.Invoke(true);
        Interactable.isInteractable = false;
    }
    private void FireOff()
    {
        WaterColliderGameObject.SetActive(false);
        delegateFire?.Invoke(false);
        Interactable.isInteractable = true;
    }

    public override void ActivePotionEffect()
    {
        Particles.Play();
        IsOnFire();
    }
    public override void StopPotionEffect()
    {
        FireOff();
    }
}
