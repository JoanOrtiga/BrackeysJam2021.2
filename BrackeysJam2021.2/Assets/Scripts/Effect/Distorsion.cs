using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distorsion : PotionEffect
{
    public GameObject distorsion;
    private bool apply = false;

    private void Awake()
    {
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
        apply = true;

        ChangeToDistorsion();
    }
    public override void StopPotionEffect()
    {
        apply = false;
    }
}
