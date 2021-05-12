using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Magnet : MonoBehaviour
{
    [SerializeField]
    public float forceFactor = 200f;
    private Rigidbody rb = null;
    private bool isOn = false;

    private void FixedUpdate()
    {
        if (isOn)
            rb.AddForce((transform.position - rb.position) * forceFactor * Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            rb = other.GetComponent<Rigidbody>();
            isOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        rb = null;
        isOn = false;
    }
}
