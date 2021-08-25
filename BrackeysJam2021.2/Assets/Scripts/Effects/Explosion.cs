using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float rad = 0.5f;
    List<GameObject> objectsNear;
    private float modifier = 2f;
    private float power = 10f;

    public Collider[] coll;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, rad);
    }
    private void Start()
    {
        print("a");

        coll = Physics.OverlapSphere(transform.position, rad);

        foreach (Collider c in coll)
        {
            print("a222");

            Rigidbody rb = c.GetComponent<Rigidbody>();

            if(rb!=null)
                rb.AddExplosionForce(power, transform.position, rad);
        }
    }


}
