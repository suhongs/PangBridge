using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private GameManager gm;
    private GameObject ToolUI; //도구 클릭시 우측의 UI
    private Rigidbody rigid; //0501 추가, 겹침 현상 구현을 위해
    private Vector3 InitialPosition; // 움직일 때 최초 위치 (겹쳤을 때 돌아갈 위치)

    public Color StartColor;
    
    
    

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //ToolUI = GameObject.Find("MainCanvas").transform.GetChild(7).gameObject;
        ToolUI = gm.ToolUI;
        StartColor = gameObject.GetComponent<MeshRenderer>().material.color;
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        //Debug.Log("Working Check"); //Mesh Collider에서는 작동을 하지 않음? 일단 Box Collider로 대체
        if (gameObject.tag == "Tool")
        {
            if(!gm.CanPlace)
            {
                return;
            }
            InitialPosition = transform.position; //추가
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            ToolUI.SetActive(true);
            ToolUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            ToolUI.GetComponent<RectTransform>().sizeDelta = new Vector2(transform.localScale.x * 50, transform.localScale.y * 50);

            //GameObject ToolName = GameObject.Find("MainCanvas/ToolUI/ToolUIBox/ToolNameBox").transform.GetChild(0).gameObject;
            //ToolName.GetComponent<Text>().text = gameObject.name;

            if (gm.SelectedTool != null)
                gm.SelectedTool.GetComponent<MeshRenderer>().material.color = StartColor;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

            try
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            catch
            {
                gameObject.GetComponent<SphereCollider>().isTrigger = true;
            }

            gm.SelectedTool = gameObject;
        }
    }

    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnMouseDrag()
    {
        //Debug.Log("Dragging");
        if(gameObject.tag == "Tool")
        {
            rigid.MovePosition(new Vector3(GetMouseWorldPos().x + mOffset.x, GetMouseWorldPos().y + mOffset.y, 0f));
            ToolUI.transform.position = Camera.main.WorldToScreenPoint(new Vector3(GetMouseWorldPos().x + mOffset.x, GetMouseWorldPos().y + mOffset.y, 0f));
        }
        /* old code
        if (gameObject.tag == "Tool")
        {
            transform.position = new Vector3(GetMouseWorldPos().x + mOffset.x, GetMouseWorldPos().y + mOffset.y, 0f);
            ToolUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
        */

    }

    public void OnMouseUp()
    {
        //문제점 1. Trigger Exit이 너무 늦게 일어나서 Flag의 변화를 늦게 눈치챔
        //이로 인해 Count 제한이 없는 경우 무한 루프가 일어남. Count가 너무 높아도 프로그램이 죽어버림
        //결론적으로 강제 이동은 성공했으나, 동기화 문제로 while문과 gm.CanPlace Flag가 이상적으로 동작하지 않는 상황. 개선 필요
        //float Timer = 0;
        //float TimerCheck = 0.1f;
        if(gameObject.tag == "Tool")
        {
            if (!gm.CanPlace)
            {
                rigid.MovePosition(InitialPosition);
                ToolUI.transform.position = Camera.main.WorldToScreenPoint(InitialPosition);
                //rigid.MovePosition(new Vector3(transform.position.x + 2.0f, transform.position.y + 2.0f, 0f));
                //ToolUI.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + 2.0f, transform.position.y + 2.0f, 0f));
                /* 다양한 시도의 잔해, 개선 수행 시 제거
                Debug.Log(Timer);
                while (Timer < TimerCheck)
                {
                    Timer += Time.deltaTime;

                }
                Debug.Log(Timer);
                Timer = 0;
                if(!gm.CanPlace)
                {
                    Debug.Log("동기화 테스트");
                }
                */
                /*
                while (!gm.CanPlace && count < 10)
                {
                    count++;
                    //Debug.Log("Work?");
                    rigid.MovePosition(new Vector3(transform.position.x + 2.0f, transform.position.y + 2.0f + mOffset.y, 0f));
                    Sleep(100);
                }
                */
            }
            /*
            try
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
            catch
            {
                gameObject.GetComponent<SphereCollider>().isTrigger = false;
            }
            */
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Tool" || col.gameObject.tag == "Player")
        {
            gm.CanPlace = false;
            Debug.Log(gm.CanPlace);
        }
    }
    public void OnTriggerStay(Collider col)
    {

    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Tool" || col.gameObject.tag == "Player")
        {
             gm.CanPlace = true;
            Debug.Log(gm.CanPlace);
        }
    }

}
