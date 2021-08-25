using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float rad = 3f;
    private float power = 7f;
    private float upForce = 2.5f;

    private Vector3 explosionPos;

    [SerializeField]
    private Collider[] coll;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rad);
    }

    private void Detonate()
    {
        explosionPos = transform.position;
        coll = Physics.OverlapSphere(explosionPos, rad);

        foreach (Collider c in coll)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, rad,upForce, ForceMode.Impulse);
                print("impulsao");
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Detonate();
        }
    }

}
