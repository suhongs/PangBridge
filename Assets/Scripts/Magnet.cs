using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            other.transform.position += (transform.position - other.transform.position).normalized * Time.deltaTime * moveSpeed;
        }
    }
}
