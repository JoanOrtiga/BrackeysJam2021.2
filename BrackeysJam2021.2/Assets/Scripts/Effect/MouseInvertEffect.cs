using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInvertEffect : PotionEffect
{
    private bool applied = false;
    private float timer = 0;
    private float valueTimer = 30f; //secs

    public delegate void MouseInvertDelegate(bool valueInvert);
    public static MouseInvertDelegate DelegateMouseInvert;
    public override void ActivePotionEffect()
    {
        applied = true;
        DelegateMouseInvert?.Invoke(true);
    }

    private void Update()
    {
        if (applied)
        {
            timer += Time.deltaTime;
            print(timer);
            if (timer >= valueTimer)
            {
                DelegateMouseInvert?.Invoke(false);
                timer = 0;
                applied = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
            ActivePotionEffect();
    }
}
