using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : CaosEffect
{
    [SerializeField]
    private float rad = 3f;
    private float power = 7f;
    private float upForce = 2.5f;

    private Vector3 explosionPos;

    public override void ActiveEffectCaos()
    {
        Detonate();
    }

    [SerializeField]

    private void Detonate() //FUNCION PARA ACTIVAR EXPLOSIÓN
    {
        
        explosionPos = transform.position;
        Collider[] coll = Physics.OverlapSphere(explosionPos, rad);

        foreach (Collider c in coll)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, rad, upForce, ForceMode.Impulse);
            }
        }
    }
}
