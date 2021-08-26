using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mareo : CaosEffect
{
    public GameObject Distorsion;
    //private bool IsDistorsion = false;
    private bool applied = false;
    private float timer = 0;
    private float valueTimer = 30f; //secs

    private void Start()
    {
        Distorsion.gameObject.SetActive(false);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K)) //pruebas
        //{
        //    IsDistorsion = !IsDistorsion;
        //    if (IsDistorsion)
        //        ChangeToDistorsion();
        //    else
        //        ChangeToNormal();
        //}

        if (applied)
        {
            timer += Time.deltaTime;
            if (timer >= valueTimer)
            {
                ChangeToNormal();
                applied = false;
                timer = 0;
            }
        }
    }

    private void ChangeToDistorsion()
    {
        Distorsion.gameObject.SetActive(true);
    }

    private void ChangeToNormal()
    {
        Distorsion.gameObject.SetActive(false);
    }

    public override void ActiveEffectCaos()
    {
        ChangeToDistorsion();
        applied = true;
    }
}
