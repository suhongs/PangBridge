using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_ReflectMarble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 colpoint = other.transform.position;

            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
            Vector3 inNormal = Vector3.Normalize(
                colpoint - transform.position);
            rigid.AddForce(inNormal.normalized * 1000f);
        }
    }
}
