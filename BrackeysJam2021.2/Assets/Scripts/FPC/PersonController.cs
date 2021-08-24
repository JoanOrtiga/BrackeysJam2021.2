using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private float x;
    private float z;
    
    [SerializeField]
    private float speed = 10f;

    private Vector3 move;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }
    //private void FixedUpdate()
    //{
        
    //}

    private void FixedUpdate()
    {
        MovementData();
    }
    private void MovementData()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = (transform.right * x + transform.forward * z).normalized;
        rigidbody.velocity = move * speed * Time.deltaTime;
    }
    
}
