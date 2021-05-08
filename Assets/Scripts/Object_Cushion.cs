using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Cushion : MonoBehaviour
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
            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();

            rigid.velocity = new Vector3(0, 0, 0);
        }
    }
}
