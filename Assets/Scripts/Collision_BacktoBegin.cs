using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_BacktoBegin : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    { 
	if(other.gameObject.tag == "Player")
	{
		Debug.Log("초기 이동 작동");
		Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
		rigid.transform.position = new Vector3(-13, 5, -4);
	}
    }
}
