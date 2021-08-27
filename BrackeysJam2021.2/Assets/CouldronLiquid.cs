using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldronLiquid : MonoBehaviour
{
    private Material _liquidMaterial;

    private void Awake()
    {
        _liquidMaterial = GetComponent<Renderer>().material;
    }
}
