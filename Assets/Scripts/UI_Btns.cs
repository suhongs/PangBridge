using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Btns : MonoBehaviour
{
    public GameObject ToolContainer=null;
    public GameObject Player;
    public Transform ResetPoint;

    private void Start()
    {
        Player = GameObject.Find("Player");
        ResetPoint = GameObject.Find("ResetPoint").transform;
    }

    public void ToggleToolBtn()
    {
        ToolContainer.SetActive(!ToolContainer.activeSelf);
    }
    public void ResetBtn()
    {
        Player.transform.position = ResetPoint.position;
    }
}
