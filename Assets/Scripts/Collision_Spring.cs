using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Spring : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    { 
	if(other.gameObject.tag == "Player")
	{
		Debug.Log("스프링 작동");
		Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
		rigid.AddForce(new Vector3(0,1,0) * 1000f);
	}
    }
}
