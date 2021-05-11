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
    public GameObject ShopPanel = null;

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
        gm.ResetAllSelect();
        rb.useGravity = true;
        GameManager.isGaming = true;
        Player.GetComponent<SphereCollider>().enabled = true;
        Player.GetComponent<SphereCollider>().isTrigger = false;
        Player.GetComponent<Rigidbody>().isKinematic = false;
        StartButton.SetActive(false);
        StopButton.SetActive(true);
        if(ShopPanel.GetComponent<Animator>().GetBool("open"))
            ShopPanel.GetComponent<Animator>().SetBool("open", !ShopPanel.GetComponent<Animator>().GetBool("open"));

        if(gm.SelectedTool != null)
        {
            gm.SelectedTool = null;
            gm.ToolUI.SetActive(false);
        }
    }

    public void StopBtn()
    {
        GameManager.isGaming = false;
        gm.ResetAllSelect();
        Player.transform.position = gm.ResetPoint.position; //플레이어를 reset point로 이동
        Player.transform.rotation = Quaternion.identity;
        rb.useGravity = false; //플레이어 중력작용x
        rb.velocity = Vector3.zero; //플레이어에게 받던 힘x

        //Player.GetComponent<SphereCollider>().enabled = false; //플레이어 collider 끔
        Player.GetComponent<SphereCollider>().isTrigger = true; //충돌은 발생하지 않더라도 겹침은 해결해야하므로
        Player.GetComponent<Rigidbody>().isKinematic = true;    //오브젝트랑 반응 안해야하는데...
        Player.transform.localScale = new Vector3(1, 1, 1);

        gm.InitializeStar();
        StartButton.SetActive(true);
        StopButton.SetActive(false);
        Destroy(Player.gameObject.GetComponent<ConstantForce>());
    }

    public void ResetBtn()
    {
        gm.ResetAllSelect();
        GameManager.isGaming = false;
        GameObject [] tools = GameObject.FindGameObjectsWithTag("Tool"); //Tool태그의 오브젝트 검색 후 배열에 담음

        for(int i=0; i<tools.Length; i++)
        {
            Destroy(tools[i]); //Tool들 제거
        }

        Player.transform.localScale = new Vector3(1, 1, 1);
        Player.transform.position = gm.ResetPoint.position; //플레이어를 reset point로 이동
        Player.transform.rotation = Quaternion.identity;
        rb.useGravity = false; //플레이어 중력작용x
        rb.velocity = Vector3.zero; //플레이어에게 받던 힘x

        //Player.GetComponent<SphereCollider>().enabled = false; //플레이어 collider 끔
        Player.GetComponent<SphereCollider>().isTrigger = true; //충돌은 발생하지 않더라도 겹침은 해결해야하므로
        Player.GetComponent<Rigidbody>().isKinematic = true;    //오브젝트랑 반응 안해야하는데...

        gm.currentCoin = gm.startCoin;
        gm.InitializeStar();
        StartButton.SetActive(true);
        StopButton.SetActive(false);
        Destroy(Player.gameObject.GetComponent<ConstantForce>());

    }

    public void ShopBtn()
    {
        if (!GameManager.isGaming)
        {
            if (ShopPanel != null)
            {
                Animator animator = ShopPanel.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");
                    animator.SetBool("open", !isOpen);
                }
            }
        }
    }

    public void SellBtn()
    {
        gm.currentCoin += int.Parse(gm.SelectedTool.transform.GetChild(0).name);
        Destroy(gm.SelectedTool.gameObject);
        gm.ResetAllSelect();
        gm.UpdateUI();
    }


    public void RotateBtn()
    {
        //gm.GetComponent<GameManager>().rotateMode = true;
    }
}
