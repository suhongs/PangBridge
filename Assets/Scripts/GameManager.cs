using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform ResetPoint; //초기화 버튼 클릭시 이동할 위치
    public int StartCoin = 5; //게임시작시 지급될 코인수
    public Text CurrentCoin; //현재 코인수

    // Start is called before the first frame update
    void Start()
    {
        CurrentCoin.text = StartCoin.ToString();
    }

}
