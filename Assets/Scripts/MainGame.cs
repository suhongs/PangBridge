using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initPos;
    GameObject player;
    public GameObject pauseBtn, startBtn;
    public GameObject NewItem;
    bool isStarted = false;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
        initPos = player.transform.position;
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
            player.transform.position = initPos;
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

    public void ItemBtn()
    {
        NewItem = Resources.Load("Block") as GameObject;
        Vector3 Position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 50.0f, -Camera.main.transform.position.z));
        GameObject item = Instantiate(NewItem);
        item.transform.position = Position;
    }
}
