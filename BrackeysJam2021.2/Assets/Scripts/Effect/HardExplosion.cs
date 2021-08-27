using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardExplosion : PotionEffect
{
    [SerializeField]
    private float rad = 3f;
    private float power = 7f;
    private float upForce = 2.5f;

    private Vector3 explosionPos;

    private bool apply = false;
    private bool runOnce = false;


    public override void ActivePotionEffect()
    {
        apply = true;
    }

    private void Update()
    {
        if (apply)
        {
            if (Mathf.RoundToInt(EffectManager.timer) % 10 == 0 && !runOnce)
            {
                print("bomba");
                runOnce = true;
                HardDetonate();
            }
            else if (Mathf.RoundToInt(EffectManager.timer) % 10 > 0)
            {
                runOnce = false;
            }
        }
    }
    public override void StopPotionEffect()
    {
        apply = false;
    }
    private void HardDetonate()
    {
        explosionPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        print(GameObject.FindGameObjectWithTag("Player").name);
        Collider[] coll = Physics.OverlapSphere(explosionPos, rad);

        foreach (Collider c in coll)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, rad, upForce, ForceMode.Impulse);
            }
        }
    }
}
