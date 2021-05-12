using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Key : MonoBehaviour
{

    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool isGameStarted;

    void Start()
    {
        isGameStarted = true;
        defaultScale = transform.localScale;
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                transform.localScale = defaultScale;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                isGameStarted = true;
            }
            defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신
        }
    }

}
