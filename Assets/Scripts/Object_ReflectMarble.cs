using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_ReflectMarble : MonoBehaviour
{
    private GameObject nodeParticle;
    // Start is called before the first frame update
    void Start()
    {
        nodeParticle = Resources.Load("Prefab/Particles/Star") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 particlepoint = other.contacts[0].point;
            Instantiate(nodeParticle, new Vector3(particlepoint.x, particlepoint.y, -1f), transform.rotation);

            Vector3 colpoint = other.transform.position;

            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
            Vector3 inNormal = Vector3.Normalize(
                colpoint - transform.position);
            rigid.AddForce(inNormal.normalized * 1000f);
        }
    }
}
