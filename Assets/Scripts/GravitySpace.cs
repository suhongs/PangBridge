using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySpace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.AddComponent<ConstantForce>();
            other.gameObject.GetComponent<ConstantForce>().force = new Vector3(0f, 12f, 0f);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            Destroy(other.gameObject.GetComponent<ConstantForce>());
        }
    }
}
