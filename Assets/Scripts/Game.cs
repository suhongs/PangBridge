using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initPos;
    GameObject ball;
    public GameObject pauseBtn, startBtn;
    bool isStarted = false;

    void Start()
    {
        ball = GameObject.Find("Ball");
        rb = ball.GetComponent<Rigidbody>();
        initPos = ball.transform.position;
        pauseBtn.SetActive(false);
    }

    public void StartBtn()
    {
        isStarted = true;
        UpdateBtn();
    }

    public void PauseBtn()
    {
        isStarted = false;
        UpdateBtn();
    }

    public void UpdateBtn()
    {
        if (isStarted)
        {
            rb.useGravity = true;
            startBtn.SetActive(false);
            pauseBtn.SetActive(true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            ball.transform.position = initPos;
            startBtn.SetActive(true);
            pauseBtn.SetActive(false);
        }
    }

    public void ResetBtn()
    {
        isStarted = false;
        UpdateBtn();
        // 사용자가 놓은 도구 초기화
    }

    public void SettingBtn()
    {
        // 세팅 메뉴 active
    }
}
