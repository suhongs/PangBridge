using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int[] LevelScore = new int[10];
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        // 1,2,3 => 스코어, 0 => 현재 스테이지, -1 => 잠김

        // 초기 설정
        LevelScore = new int[] { 0, -1, -1, -1, -1, -1, -1, -1, -1, -1};

        // 스테이지 스코어 불러옴
        for (int i = 0; i < LevelScore.Length; i++)
        {
            int stage = i + 1;
            if (PlayerPrefs.HasKey("stage" + stage))
            {
                LevelScore[i] = PlayerPrefs.GetInt("stage" + stage);
            }
            else
            {
                LevelScore[i] = -1;
            }
        }
        if (LevelScore[0] == -1) LevelScore[0] = 0;
        


        for (int i=0; i < LevelScore.Length; i++)
        {
            int curLevel = i + 1;
            GameObject levelObject = GameObject.Find(curLevel.ToString());

            if(LevelScore[i] > 0)
            {
                Image scoreImage = levelObject.transform.GetChild(1).GetChild(0).GetComponent<Image>();
                scoreImage.sprite = Resources.Load<Sprite>("star"+LevelScore[i]);
                TextMeshProUGUI levelText = levelObject.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
                levelText.text = "<#636363>" + levelObject.transform.name + "</color>";
                levelText.raycastTarget = false;
            }

            if (LevelScore[i] == 0)
            {
                Image scoreImage = levelObject.transform.GetChild(1).GetChild(0).GetComponent<Image>();
                scoreImage.sprite = Resources.Load<Sprite>("star0");
                TextMeshProUGUI levelText = levelObject.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
                levelText.text = levelObject.transform.name;
                levelText.raycastTarget = false;
                Image buttonImage = levelObject.transform.GetChild(0).GetComponent<Image>();
                buttonImage.sprite = Resources.Load<Sprite>("frame_stage_current");
            }

            if (LevelScore[i] < 0)
            {
                Button levelBtn = levelObject.transform.GetChild(0).GetComponent<Button>();
                levelBtn.interactable = false;
                levelObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

}
