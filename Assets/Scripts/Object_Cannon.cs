﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Cannon : MonoBehaviour
{
    private GameManager gm;
    Camera cam = null;
    [SerializeField] GameObject CannonDir = null;
    private GameObject player = null;
    private Vector3 mouseDir;
    private Vector3 boxColliderSize;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
        boxColliderSize = GetComponent<BoxCollider>().size;
    }
    private void Update()
    {
        if(gm.isCannon) //대포가 마우스 방향으로 향하게
        {
            CannonDir.transform.RotateAround(transform.position, Vector3.forward, 75f * Time.deltaTime);
        }
        if(gm.isCannon)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("a");
                player.GetComponent<Rigidbody>().velocity = CannonDir.transform.right * 20f;
                player.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player = other.gameObject;

            //플레이어 세팅 초기화
            player.GetComponent<Rigidbody>().useGravity = false; //플레이어의 중력을 끄고
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.transform.position = gameObject.transform.position;
            gameObject.GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
            gm.isCannon = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponent<BoxCollider>().size = boxColliderSize;
            gm.isCannon = false;
        }
    }
}
