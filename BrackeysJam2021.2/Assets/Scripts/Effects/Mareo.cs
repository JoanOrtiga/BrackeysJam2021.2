using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mareo : MonoBehaviour
{
    public UnityEngine.GameObject Distorsion;
    private bool change = false;

    private void Start()
    {
        Distorsion.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) //pruebas
        {
            change = !change;
            if (change)
                ChangeToDistorsion();
            else
                ChangeToNormal();
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

}
