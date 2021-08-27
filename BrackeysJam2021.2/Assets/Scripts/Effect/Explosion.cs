using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PotionEffect
{
    [SerializeField]
    private float rad = 3f;
    private float power = 7f;
    private float upForce = 2.5f;

    private Vector3 explosionPos;

    public override void ActivePotionEffect()
    {
        StartCoroutine(Detonate());
    }
    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(0.25f);
        
        explosionPos = transform.position;
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
