using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Key : MonoBehaviour
{

    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool isGameStarted;
    private SphereCollider sc;
    private Rigidbody rb;

    void Start()
    {
        isGameStarted = true;
        defaultScale = transform.localScale;
        defaultPosition = transform.position;
        sc = gameObject.GetComponent<SphereCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                rb.useGravity = true;
                isGameStarted = false;
                sc.isTrigger = false;
                rb.isKinematic = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                transform.localScale = defaultScale;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = false;
                isGameStarted = true;
                sc.isTrigger = true;
                rb.isKinematic = true;
            }
            defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신
        }
    }

}
