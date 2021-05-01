using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private GameManager gm;
    private GameObject ToolUI; //도구 클릭시 판매,회전 UI
    public Color StartColor;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //ToolUI = GameObject.Find("MainCanvas").transform.GetChild(7).gameObject;
        ToolUI = gm.ToolUI;
        StartColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseDown()
    {
        //Debug.Log("Working Check"); //Mesh Collider에서는 작동을 하지 않음? 일단 Box Collider로 대체
        if (gameObject.tag == "Tool")
        {
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
        if (gameObject.tag == "Tool")
        {
            transform.position = new Vector3(GetMouseWorldPos().x + mOffset.x, GetMouseWorldPos().y + mOffset.y, 0f);
            ToolUI.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }

    }

}
