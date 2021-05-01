using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private GameManager gm;
    Camera cam = null;
    [SerializeField] GameObject CannonDir = null;
    private GameObject player = null;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
    }
    private void Update()
    {
        if(gm.isCannon) //대포가 마우스 방향으로 향하게
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitResult;
            if(Physics.Raycast(ray, out hitResult))
            {
                Vector3 mouseDir = new Vector3(hitResult.point.x, hitResult.point.y, transform.position.z) - transform.position;
                CannonDir.transform.LookAt(mouseDir);
            }
            //Vector3 camPos = Camera.main.transform.position;
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camPos.z));
            //Vector3 target = new Vector3(mousePos.x, mousePos.y, 0f);
            //CannonDir.transform.LookAt(target);
        }
        if(gm.isCannon)
        {
            if(Input.GetMouseButtonDown(0))
            {
                player.GetComponent<Rigidbody>().velocity = CannonDir.transform.right * 10f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player = other.gameObject;
            Debug.Log("trigger enter test");

            //플레이어 세팅 초기화
            player.GetComponent<Rigidbody>().useGravity = false; //플레이어의 중력을 끄고
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.transform.position = gameObject.transform.position;
            gm.isCannon = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("trigger exit test");
            gm.isCannon = false;
        }
    }
}
