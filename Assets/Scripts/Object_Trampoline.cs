using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Trampoline : MonoBehaviour
{
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 inNormal = Vector3.Normalize(
            transform.position - rigid.transform.position);
        inNormal.z = 0;
        //float force = Mathf.Sqrt(rigid.velocity.x * rigid.velocity.x + rigid.velocity.y * rigid.velocity.y) * 50f;
        //rigid.AddForce(-inNormal * force);
        audiosource.Play();
        rigid.AddForce(-inNormal * 400f);
    }
}
