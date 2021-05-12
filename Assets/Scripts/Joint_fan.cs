using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_fan : MonoBehaviour
{
    private GameManager gm = null;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool isGameStarted;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameStarted = true;
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                //gameObject.transform.rotation = Quaternion.identity;
                //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 
                //gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                isGameStarted = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Key")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<HingeJoint>().useMotor = true;
        }
    }
}
