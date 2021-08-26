using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEffect : PotionEffect
{
    [SerializeField]
    private float StrongValueEffect = 5f;
    private float defaultValue = 1f;
    private bool applied = false;
    private float timer = 0;
    private float valueTimer = 30f; //secs

    public delegate void StrongDelegate(float newValue);
    public static StrongDelegate DelegatStrong;

    public override void ActivePotionEffect()
    {
        ApplyStrongEffect();
    }

    private void ApplyStrongEffect()
    {
        DelegatStrong?.Invoke(StrongValueEffect);
        applied = true;
    }
    private void Update()
    {
        if (applied)
        {
            timer += Time.deltaTime;
            print(timer);
            if (timer >= valueTimer)
            {
                DelegatStrong?.Invoke(defaultValue);
                timer = 0;
                applied = false;
            }
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //    ActivePotionEffect();
    }
}
