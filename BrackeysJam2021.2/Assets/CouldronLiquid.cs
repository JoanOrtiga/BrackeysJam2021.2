using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldronLiquid : MonoBehaviour
{
    private Material _liquidMaterial;
    private float _fillAmmount;
    private static readonly int Fill = Shader.PropertyToID("_Fill");
    private static readonly int TopColor = Shader.PropertyToID("TopColor");


    private void Awake()
    {
        _liquidMaterial = GetComponent<Renderer>().material;
        RestartPotion();
        FillCauldron();
        FillCauldron();
        ChangeColor(Color.green);
    }

    public void ChangeColor(Color color)
    {
        _liquidMaterial.SetColor(TopColor, color);
    }

    public void FillCauldron()
    {
        _fillAmmount += 0.2f;
        _liquidMaterial.SetFloat(Fill, _fillAmmount);
    }

    private void RestartPotion()
    {
        _fillAmmount = 0;
        _liquidMaterial.SetFloat(Fill, _fillAmmount);
        ChangeColor(Color.red);
    }
}
