using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mareo : MonoBehaviour
{
    public GameObject Distorsion;
    private bool IsDistorsion = false;

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
    }

    private void ChangeToDistorsion()
    {
        Distorsion.gameObject.SetActive(true);
    }

    private void ChangeToNormal()
    {
        Distorsion.gameObject.SetActive(false);
    }

}
