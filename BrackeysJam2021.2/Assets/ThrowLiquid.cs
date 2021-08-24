using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLiquid : MonoBehaviour
{
    private Material liquid;
    public Transform liquidTransform;
    public float lowRotation;
    private static readonly int Fill = Shader.PropertyToID("_Fill");

    private void Awake()    
    {
        liquid = liquidTransform.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Debug.Log((transform.eulerAngles.z - 270f) + "    " + (Mathf.Abs(transform.eulerAngles.z)-270f) / 90f);
        liquid.SetFloat(Fill, (Mathf.Abs(transform.eulerAngles.z)-270f) / 90f);
    }
}
