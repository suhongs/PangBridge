using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_CubeBlock : MonoBehaviour
{
    //충돌할 때 마다 색을 바꿈
    private GameObject nodeParticle;


    // Start is called before the first frame update
    void Start()
    {
        nodeParticle = Resources.Load("Prefab/Particles/Cube_Collision_White") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 colpoint = other.contacts[0].point;
        if (other.gameObject.tag == "Player")
        {
            //Instantiate(nodeParticle, new Vector3(other.transform.position.x, other.transform.position.y, -0.2f), nodeParticle.transform.rotation);
            Instantiate(nodeParticle, new Vector3(colpoint.x, colpoint.y, -0.2f), nodeParticle.transform.rotation);
        }
    }
}
