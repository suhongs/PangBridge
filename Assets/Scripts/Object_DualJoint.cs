using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_DualJoint : MonoBehaviour
{
    private GameManager gm;

    private Quaternion defaultRotationOne;
    private Quaternion defaultRotationTwo;

    private Vector3 defaultPositionOne;
    private Vector3 defaultPositionTwo;

    private bool isGameStarted;
    private float hingevalue;

    private GameObject CubeOne;
    private GameObject CubeTwo;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = true;
        hingevalue = 1;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //최초 배치 시 
        //3번째 / 4번째 아이템의 Position / Rotation 저장
        CubeOne = transform.GetChild(2).gameObject;
        CubeTwo = transform.GetChild(3).gameObject;

        defaultPositionOne = CubeOne.transform.localPosition;
        defaultPositionTwo = CubeTwo.transform.localPosition;

        defaultRotationOne = CubeOne.transform.localRotation;
        defaultRotationTwo = CubeTwo.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                CubeOne.GetComponent<Rigidbody>().isKinematic = false;
                CubeTwo.GetComponent<Rigidbody>().isKinematic = false;
                isGameStarted = false;
            }

            if(Input.GetMouseButtonDown(0) && gm.isCannon == false)
            {
                CubeOne.GetComponent<HingeJoint>().axis = new Vector3(0, hingevalue, 0);
                CubeTwo.GetComponent<HingeJoint>().axis = new Vector3(0, -hingevalue, 0);

                hingevalue = -hingevalue;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                CubeOne.transform.localPosition = defaultPositionOne;
                CubeOne.transform.localRotation = defaultRotationOne;

                CubeTwo.transform.localPosition = defaultPositionTwo;
                CubeTwo.transform.localRotation = defaultRotationTwo;

                CubeOne.GetComponent<HingeJoint>().axis = new Vector3(0, -1, 0);
                CubeTwo.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
                hingevalue = 1;

                CubeOne.GetComponent<Rigidbody>().isKinematic = true;
                CubeTwo.GetComponent<Rigidbody>().isKinematic = true;
                isGameStarted = true;
            }
        }

        //게임 중일 때       : 돌아!
        //3, 4번째 자식 Rigidbody의 iskinematic을 껐다 켰다 

        //게임 중이 아닐 때  : 멈춰!
        //Rotation Default로 고정
        //포지션 상시 갱신
    }
}
