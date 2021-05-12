using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    public float forceFactor = 200f;
    private Rigidbody rb = null;

    private void FixedUpdate()
    {
        rb.AddForce((transform.position - rb.position) * forceFactor * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            rb = other.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        rb = null;
    }
}
