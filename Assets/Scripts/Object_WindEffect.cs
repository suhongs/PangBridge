using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_WindEffect : MonoBehaviour
{
   // private GameManager gm;
    private GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
       //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && GameManager.isGaming == true)
        {
            Debug.Log("Trigger Check");
            //other에게 바람 효과 지속 적용
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 15f);
        }
    }
}
