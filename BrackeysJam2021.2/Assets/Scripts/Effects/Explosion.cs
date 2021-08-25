using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float rad = 0.5f;
    private float power = 10f;

    public Collider[] coll;

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, rad);
    //}
    private void Explosive()
    {
        print("a");

        coll = Physics.OverlapSphere(transform.position, rad);

        for (int i = 0; i < coll.Length; i++)
        {
            print("a222");

            Rigidbody rb = coll[i].GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, rad);
                print("a");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Impact")
        {
            Explosive();
           // Destroy(this.gameObject.);
        }
    }
}
