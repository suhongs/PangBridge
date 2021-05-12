using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject_Star : MonoBehaviour
{
    private GameManager gm;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool counted;
    private bool isGameStarted;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameStarted = true;
        counted = false;
        defaultScale = transform.localScale;
    }

    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                counted = false;
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.localScale = defaultScale;
                isGameStarted = true;
            }
            defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신 (Star을 유저가 배치하는 경우가 발생하도록 해야하나? 일단 혹시 모르니 내버려둠
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !counted)
        {
            counted = true;
            transform.localScale = new Vector3(0, 0, 0);
            gm.currentStar++;
            gm.UpdateUI();
            if (gameObject.tag == "Goal")
            {
                gm.isCleared = true;
            }
        }

        
    }
}
