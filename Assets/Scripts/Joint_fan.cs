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
    }
    private void Update()
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
                isGameStarted = true;
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Key")
        {
            gameObject.GetComponent<HingeJoint>().useMotor = true;
        }
    }
}
