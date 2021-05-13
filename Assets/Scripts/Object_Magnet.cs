using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Magnet : MonoBehaviour
{
    [SerializeField]
    public float force = 200f;
    private Rigidbody rb = null;
    private GameManager gm = null;
    private bool isGameStarted;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameStarted = true;
        gameObject.GetComponent<SphereCollider>().radius = 10f;
    }
    private void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                gameObject.GetComponent<SphereCollider>().radius = 50f;
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                gameObject.GetComponent<SphereCollider>().radius = 10f;
                isGameStarted = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            rb = other.GetComponent<Rigidbody>();
            Rigidbody magnetRb = gameObject.GetComponent<Rigidbody>();
            if (rb.mass > magnetRb.mass)
            {
                //add force to the rigidbody of the magnet
                magnetRb.AddForce(-(magnetRb.position - rb.position) * force);
                //returns
                return;
            }

            //add force to the rigidbody that must be attracted
            rb.AddForce((magnetRb.position - rb.position) * force * rb.mass * Time.deltaTime);
        }
    }
}
