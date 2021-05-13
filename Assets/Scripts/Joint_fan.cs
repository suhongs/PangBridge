using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_fan : MonoBehaviour
{
    private GameManager gm = null;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool isGameStarted;
    private Rigidbody rb;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameStarted = true;
        defaultPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                isGameStarted = false;
                gameObject.GetComponent<HingeJoint>().useMotor = true;
                rb.isKinematic = false;
                if (defaultPosition != gameObject.transform.position)
                    defaultPosition = gameObject.transform.position;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                gameObject.transform.rotation = Quaternion.identity;
                rb.velocity = Vector3.zero; 
                rb.angularVelocity = Vector3.zero;
                gameObject.GetComponent<HingeJoint>().useMotor = false;
                rb.isKinematic = true;
                isGameStarted = true;
            }
        }
    }
}
