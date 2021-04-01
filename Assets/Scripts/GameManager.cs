using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Transform ResetPoint; //초기화 버튼 클릭시 이동할 위치
    public int StartCoin = 5; //게임시작시 지급될 코인수
    public Text CurrentCoin; //현재 코인수

    public int MaxStar = 3; //최대 별 수
    public Text StartStar = null;
    public Text CurrentStar = null; //현재 별 수

    public GameObject[] stars; //별들을 담을 배열

    public GameObject SelectedTool = null; //클릭으로 선택한 도구
    // Start is called before the first frame update
    void Start()
    {
        CurrentCoin.text = StartCoin.ToString();
        StartStar.text = "/ " + MaxStar.ToString();
        CurrentStar.text = "0";
    }
    public void InitializeStar() //reset버튼 클릭시 star 값 및 위치 초기화
    {
        //별도 스크립트 혹은 함수로 옮기는 것을 고려
        stars = GameObject.FindGameObjectsWithTag("Star");
        for (int i = 0; i < stars.Length; i++)
        {
            Destroy(stars[i]); //
        }
        GameObject newstar = Resources.Load("Prefab/Star") as GameObject;
        GameObject starone = Instantiate(newstar, new Vector3(-19.91f, -9.03f, -0.03f), newstar.transform.rotation);
        GameObject startwo = Instantiate(newstar, new Vector3(-23.37f, -12.48f, -0.03f), newstar.transform.rotation);
        GameObject starthree = Instantiate(newstar, new Vector3(-27.07f, -16.11f, -0.03f), newstar.transform.rotation);


        CurrentStar.text = "0";
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false) //클릭한게 오브젝트가 아닌 ui일때
            {
                ResetAllSelect();
            }
        }
    }

    public void ResetAllSelect() //바탕 클릭 이벤트
    {
        SelectedTool = null;
        GameObject ToolUI = GameObject.Find("MainCanvas").transform.GetChild(7).gameObject;
        ToolUI.SetActive(false);

        GameObject[] tools = GameObject.FindGameObjectsWithTag("Tool"); //Tool태그의 오브젝트 검색 후 배열에 담음

        for (int i = 0; i < tools.Length; i++)
        {
            tools[i].GetComponent<MeshRenderer>().material.color = tools[i].GetComponent<DragObject>().StartColor; //모든 도구 색 초기화
        }
    }
}
