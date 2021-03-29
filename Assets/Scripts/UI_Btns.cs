using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Btns : MonoBehaviour
{
    public GameObject ToolContainer=null;
    public GameObject Player;
    public GameManager gm;
    public GameObject SettingContainer;

    private void Start()
    {
        Player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ToggleToolBtn()
    {
        ToolContainer.SetActive(!ToolContainer.activeSelf);
    }
    public void ResetBtn()
    {
        Player.transform.position = gm.ResetPoint.position;
        Player.GetComponent<Player>().Setinitialize();
        gm.CurrentCoin.text = gm.StartCoin.ToString();
    }
    public void OpenSetting()
    {
        SettingContainer.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingContainer.SetActive(false);
    }
}
