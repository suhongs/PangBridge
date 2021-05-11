﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BrokenBlock : MonoBehaviour
{
    private int collisioncheck;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool isGameStarted;

    //3회 hit시 사라지는 block

    // Start is called before the first frame update
    void Start()
    {
        collisioncheck = 0;
        isGameStarted = true;
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                defaultPosition = transform.position;
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                transform.localScale = defaultScale;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Material/Skyblue") as Material;
                collisioncheck = 0;
                isGameStarted = true;
            }
            defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신
        }
    }

    
    void OnCollisionEnter(Collision other)
    {
    Debug.Log("collision");
        if (other.gameObject.tag == "Player")
        {
            collisioncheck++;
            //collision이 횟수에 따라 파랑->빨강->파괴 순서로 진행
            if (collisioncheck == 1)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (collisioncheck == 2)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if (collisioncheck > 2)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true; //투과되도록
                transform.localScale = new Vector3(0, 0, 0);
                //gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}