using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Btns : MonoBehaviour
{
    public GameObject Player;
    public GameManager gm;
    public GameObject SettingContainer;
    public GameObject StartButton = null;
    public GameObject StopButton = null;

    private Rigidbody rb;
    private void Start()
    {
        Player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = Player.GetComponent<Rigidbody>();
        StopButton.SetActive(false);
    }

    public void StartBtn()
    {
        rb.useGravity = true;
        Player.GetComponent<SphereCollider>().enabled = true;
        StartButton.SetActive(false);
        StopButton.SetActive(true);
    }

    public void StopBtn()
    {
        Player.transform.position = gm.ResetPoint.position; //플레이어를 reset point로 이동
        rb.useGravity = false; //플레이어 중력작용x
        rb.velocity = Vector3.zero; //플레이어에게 받던 힘x
        Player.GetComponent<SphereCollider>().enabled = false; //플레이어 collider 끔

        gm.InitializeStar();
        gm.CurrentCoin.text = gm.StartCoin.ToString(); //코인 초기화
        StartButton.SetActive(true);
        StopButton.SetActive(false);
        Destroy(Player.gameObject.GetComponent<ConstantForce>());
    }

    public void ResetBtn()
    {
        GameObject [] tools = GameObject.FindGameObjectsWithTag("Tool"); //Tool태그의 오브젝트 검색 후 배열에 담음

        for(int i=0; i<tools.Length; i++)
        {
            Destroy(tools[i]); //Tool들 제거
        }

        Player.transform.position = gm.ResetPoint.position; //플레이어를 reset point로 이동
        rb.useGravity = false; //플레이어 중력작용x
        rb.velocity = Vector3.zero; //플레이어에게 받던 힘x
        Player.GetComponent<SphereCollider>().enabled = false; //플레이어 collider 끔

        gm.InitializeStar();
        gm.CurrentCoin.text = gm.StartCoin.ToString(); //코인 초기화
        StartButton.SetActive(true);
        StopButton.SetActive(false);
        Destroy(Player.gameObject.GetComponent<ConstantForce>());

    }

    public void SellBtn()
    {
        Destroy(gm.SelectedTool.gameObject);
        gm.CurrentCoin.text = (int.Parse(gm.CurrentCoin.text) + 1).ToString(); //+1자리에 각 도구 가격 넣으면 될 듯
    }
    public void RotateBtn()
    {
        gm.GetComponent<GameManager>().rotateMode = true;
    }
}
