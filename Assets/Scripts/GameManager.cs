using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI StageText;   // 스테이지 표시
    public int currentStage; // 스테이지    !!!! 각 스테이지마다 Inspector에서 입력해야 함 !!!!

    public Transform ResetPoint; //초기화 버튼 클릭시 이동할 위치

    public int startCoin = 100; //게임시작시 지급될 코인수
    public int currentCoin = 0; //현재 코인 수
    public TextMeshProUGUI CurrentCoinText;

    public int maxStar = 3; //최대 별 수
    public int currentStar = 0; //현재 별 수
    public TextMeshProUGUI ScoreText;

    public float timer = 200; // 타이머
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
    public bool isCleared = false;   // 빨간 별 먹으면 완료

    public GameObject StageScoreUI;

    public GameObject Player;
    private Rigidbody rb;
    public GameObject StartButton;
    public GameObject StopButton;

    // Start is called before the first frame update
    void Start()
    {
        if (isGaming) isGaming = false;
        currentCoin = startCoin;
        CurrentCoinText.text = currentCoin+"$";
        ScoreText.text = currentStar + "/" + maxStar;
        TimerText.text = timer.ToString();

        ToolUI = GameObject.FindWithTag("ToolUI");
        ToolUI.SetActive(false);

        StageScoreUI = GameObject.Find("StageScoreUI");
        StageScoreUI.SetActive(false);

        Player = GameObject.Find("Player");
        StartButton = GameObject.Find("StartButton");
        StopButton = GameObject.Find("StopButton");
        Player = GameObject.Find("Player");
        rb = Player.GetComponent<Rigidbody>();
        StopButton.SetActive(false);
    }

    private void Update()
    {
        // 타이머
        if(isGaming)
        {
            if(Player.transform.position.y < -33.0f || timer <= 0)
            {
                isGaming = false;
                ResetAllSelect();
                Player.transform.position = ResetPoint.position; //플레이어를 reset point로 이동
                Player.transform.rotation = Quaternion.identity;
                rb.useGravity = false; //플레이어 중력작용x
                rb.velocity = Vector3.zero; //플레이어에게 받던 힘x

                //Player.GetComponent<SphereCollider>().enabled = false; //플레이어 collider 끔
                Player.GetComponent<SphereCollider>().isTrigger = true; //충돌은 발생하지 않더라도 겹침은 해결해야하므로
                Player.GetComponent<Rigidbody>().isKinematic = true;    //오브젝트랑 반응 안해야하는데...
                Player.transform.localScale = new Vector3(1, 1, 1);

                InitializeStar();
                StartButton.SetActive(true);
                StopButton.SetActive(false);
                Destroy(Player.gameObject.GetComponent<ConstantForce>());
            }
            timer -= Time.deltaTime;
            TimerText.text = Mathf.Floor(timer).ToString();
        }

        if (isCleared)
        {
            StageScoreUI.SetActive(true);
            if(!PlayerPrefs.HasKey("stage" + currentStage) || PlayerPrefs.GetInt("stage"+ currentStage) < currentStar)
            {
                PlayerPrefs.SetInt("stage" + currentStage, currentStar);
                PlayerPrefs.SetInt("stage" + (currentStage + 1), 0);
                PlayerPrefs.Save();
            }
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

        timer = 200;
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
