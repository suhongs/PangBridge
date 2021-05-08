using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI StageText;   // 스테이지 표시

    public Transform ResetPoint; //초기화 버튼 클릭시 이동할 위치

    public int startCoin = 100; //게임시작시 지급될 코인수
    public int currentCoin = 0; //현재 코인 수
    public TextMeshProUGUI CurrentCoinText;

    public int maxStar = 3; //최대 별 수
    public int currentStar = 0; //현재 별 수
    public TextMeshProUGUI ScoreText;

    public float timer = 200; // 타이머
    float time = 0;
    public TextMeshProUGUI TimerText;

    public GameObject[] stars; //별들을 담을 배열

    public GameObject SelectedTool = null; //클릭으로 선택한 도구
    public bool CanPlace = true;
    public bool MouseFlag = false;

    public bool rotateMode = false;         // 회전 모드

    private Vector3 mouseDownPoint;
    private Vector3 MouseUpPoint;
    private Vector3 prevPoint;

    public GameObject ToolUI;
    public float prevAngle;

    public bool isCannon = false; //대포 여부

    public bool TriggerStatus = false; //현재 선택한 오브젝트의 트리거 상태 확인 (ToolHandler와 DragObject가 공유하는 변수가 필요)
    public bool FirstTrigger = false; //현재 선택한 오브젝트의 트리거 상태 확인 (ToolHandler와 DragObject가 공유하는 변수가 필요)

    public static bool isGaming = false;

    // Start is called before the first frame update
    void Start()
    {
        currentCoin = startCoin;
        CurrentCoinText.text = currentCoin+"$";
        ScoreText.text = currentStar + "/" + maxStar;
        TimerText.text = timer.ToString();

        ToolUI = GameObject.FindWithTag("ToolUI");
        ToolUI.SetActive(false);

    }

    private void Update()
    {
        // 타이머
        if(GameManager.isGaming)
        {
            time += Time.deltaTime;
            TimerText.text = (200 - ((int)time % 60)).ToString();
        }
    }

    public void UpdateUI()
    {
        CurrentCoinText.text = currentCoin + "$";
        ScoreText.text = currentStar + "/" + maxStar;
    }

    public void InitializeStar() //reset버튼 클릭시 star 값 및 위치 초기화
    {
        //별도 스크립트 혹은 함수로 옮기는 것을 고려
        //stars = GameObject.FindGameObjectsWithTag("Star");
        //for (int i = 0; i < stars.Length; i++)
        //{
        //    Destroy(stars[i]); //
        //}
        //Star관련은 Star Object를 수정하겠습니다. 잠시동안 별이 재생성되지 않습니다.
        //GameObject newstar = Resources.Load("Prefab/Star") as GameObject;
        //GameObject starone = Instantiate(newstar, new Vector3(-19.91f, -9.03f, -0.03f), newstar.transform.rotation);
        //GameObject startwo = Instantiate(newstar, new Vector3(-23.37f, -12.48f, -0.03f), newstar.transform.rotation);
        //GameObject starthree = Instantiate(newstar, new Vector3(-27.07f, -16.11f, -0.03f), newstar.transform.rotation);

        time = 0;
        TimerText.text = 200.ToString();
        currentStar = 0;
        UpdateUI();
    }

    private void OnMouseDown()
    {
        mouseDownPoint = Input.mousePosition;
        prevPoint = mouseDownPoint;
    }

    private void OnMouseDrag()
    {
        float mZCoord;
        
        if (rotateMode)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;

            Vector3 dir = Camera.main.ScreenToWorldPoint(mousePoint) - SelectedTool.transform.position;

            float angle = Vector3.Angle(new Vector3(dir.x, dir.y, 0), new Vector3(1, 0, 0));

            if ((dir.x > 0&& dir.y <0) || dir.x < 0 && dir.y <0)
                    angle = -angle;
            SelectedTool.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void OnMouseUp()
    {
        MouseUpPoint = Input.mousePosition;
        if (EventSystem.current.IsPointerOverGameObject() == false && mouseDownPoint == MouseUpPoint) //클릭한게 오브젝트가 아닌 ui일때
        {
            ResetAllSelect();
        }
        rotateMode = false;
    }

    public void ResetAllSelect() //바탕 클릭 이벤트
    {
        rotateMode = false;
        SelectedTool = null;
        //GameObject ToolUI = GameObject.Find("MainCanvas").transform.GetChild(7).gameObject;

        ToolUI.SetActive(false);

        GameObject[] tools = GameObject.FindGameObjectsWithTag("Tool"); //Tool태그의 오브젝트 검색 후 배열에 담음

        for (int i = 0; i < tools.Length; i++)
        {
            tools[i].GetComponent<MeshRenderer>().material.color = tools[i].GetComponent<DragObject>().StartColor; //모든 도구 색 초기화
        }
        
    }


}
