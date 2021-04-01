using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tool_Canvas : MonoBehaviour
{
    public GameObject Tool = null;
    GameManager gm;
    private float RotateSpeed = 3f;
    bool isRotate = false;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        isRotate = true;
    }

    private void OnMouseDrag()
    {
        if(isRotate)
        {
            Debug.Log("drag");
            Tool.transform.Rotate(0f, -Input.GetAxis("Mouse X") * RotateSpeed, 0f, Space.World);
            Tool.transform.Rotate(-Input.GetAxis("Mouse Y") * RotateSpeed, 0f, 0f);
        }
    }
    private void OnMouseUp()
    {
        isRotate = false;
    }

    public void RotateObject() //회전버튼 클릭 후 도구 회전시킬 스크립트
    {
        isRotate = true;
    }
    public void SellBtnClick()
    {
        Destroy(Tool);
        gm.CurrentCoin.text = (int.Parse(gm.CurrentCoin.text) + 1).ToString();
    }
}
