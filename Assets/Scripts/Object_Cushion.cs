using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Cushion : MonoBehaviour
{
    private GameObject nodeParticle;
    // Start is called before the first frame update
    void Start()
    {
        nodeParticle = Resources.Load("Prefab/Particles/Cube_Cushion") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 colpoint = other.contacts[0].point;
            Instantiate(nodeParticle, new Vector3(colpoint.x, colpoint.y, -1f), transform.rotation);

            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();

            rigid.velocity = new Vector3(0, 0, 0);
        }
    }
}
