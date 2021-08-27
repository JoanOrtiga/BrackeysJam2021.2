using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PotionEffect
{
    [SerializeField]
    private float rad = 7f;
    private float power = 7f;
    private float upForce = 2.5f;

    public GameObject Caldero;
    private Vector3 explosionPos;
    public override void StopPotionEffect()
    {
        
    }
    public override void ActivePotionEffect()
    {
        Detonate();
    }
    private void Detonate()
    {   
        explosionPos = Caldero.transform.position;
        Collider[] coll = Physics.OverlapSphere(explosionPos, rad);

        foreach (Collider c in coll)
        {
            print(c);
            Rigidbody rb = c.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, rad, upForce, ForceMode.Impulse);
            }
        }
    }
}
