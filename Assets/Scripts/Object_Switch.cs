using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Switch : MonoBehaviour
{
    [SerializeField]
    GameObject panel; //사라지게 할 블럭

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Key" || collision.gameObject.tag=="Player")
        {
            Destroy(panel, 0f);
        }
    }
}
