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

    private Color lastColor;

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
        float factor = 1;//Mathf.Pow(2,2);
        lastColor = CombineColors(lastColor, color);
        _liquidMaterial.SetColor(TopColor, lastColor * factor);
    }

    public IEnumerator FillCauldron()
    {
        while (_fillAmmount >= 0.98f)
        {
            _fillAmmount += 0.01f;
            _liquidMaterial.SetFloat(Fill, _fillAmmount);
            yield return null;
        }

        yield return null;
    }

    private void RestartPotion()
    {
        _fillAmmount = 0;
        _liquidMaterial.SetFloat(Fill, _fillAmmount);
        ChangeColor(Color.red);
    }
    
    public static Color CombineColors(params Color[] aColors)
    {
        Color result = new Color(0,0,0,0);
        foreach(Color c in aColors)
        {
            result += c;
        }
        result /= aColors.Length;
        return result;
    }
}
