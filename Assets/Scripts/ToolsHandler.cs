using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ToolsHandler : MonoBehaviour
{
    string curTool = null;
    GameObject tool = null;
    GameObject prefab = null;
    bool btnClicked = false;
    private Vector3 mousePos;
    GameManager gm = null;
    public GameObject buttonTemplate;
    public GameObject content;

    [Serializable]
    public struct Tool
    {
        public string name;
        public string prefab_name;
        public int cost;
        public Sprite image;
        //public string description;
        //public int unlockLevel;
    }

    [SerializeField] Tool[] allTools;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        int N = allTools.Length;
        
        GameObject tool;
        for(int i = 0; i < N; i++)
        {
            tool = Instantiate(buttonTemplate, transform);
            tool.transform.SetParent(content.transform);
            tool.name = allTools[i].prefab_name;
            //tool.transform.Find("Image").GetComponent <Image>().sprite = allTools[i].image;
            tool.transform.Find("CostText").GetComponent<TextMeshProUGUI>().text = allTools[i].cost + "$";
            tool.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = allTools[i].name;
        }
        Destroy(buttonTemplate);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(
        new Vector3(
        Input.mousePosition.x,
        Input.mousePosition.y,
        -Camera.main.transform.position.z));

        // 도구 버튼 클릭
        if (btnClicked)
        {
            if (tool != null)
            {
                // 버튼 클릭하면 해당 오브젝트가 마우스 따라 다님
                //tool.transform.position = mousePos;
                tool.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
            }


            if (Input.GetMouseButtonDown(0))
            { 
                if (tool != null)
                {
                    // 클릭하면 따라다니던 오브젝트 그 위치에 고정

                    // !! 보드 위가 아니거나 다른 오브젝트와 겹치는 경우 놓이지 않게 하는 기능 추가해야 함 !!
                    tool = null;
                    btnClicked = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // 배치하기 전에 esc 키를 누르면 오브젝트 취소
                btnClicked = false;
                if(tool != null)
                    Destroy(tool);
            }
        }
    }

    public void OnClick()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;

        if (!btnClicked)
        {
            btnClicked = true;
            curTool = tempBtn.name;
            //Debug.Log(curTool);
            // 버튼 이름으로 프리팹 불러옴
            prefab = Resources.Load("Prefab/" + curTool) as GameObject;
            tool = MonoBehaviour.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            tool.tag = "Tool";
            gm.CurrentCoin.text = (int.Parse(gm.CurrentCoin.text)-1).ToString();
            // 리셋 버튼 누르면 태그가 Tool인 오브젝트 없애고 돈 환불처리 시키기
        }
    }
}
