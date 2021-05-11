using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int[] LevelScore;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        // 1,2,3 => 스코어, 0 => 현재 스테이지, -1 => 잠김

        // 초기 설정
        LevelScore = new int[] { 0, -1, -1, -1, -1 };

        // 스테이지 스코어 불러옴
         LevelScore = new int[] { 3, 2, 0, -1, -1 };


        for (int i=0; i < LevelScore.Length; i++)
        {
            int curLevel = i + 1;
            GameObject levelObject = GameObject.Find(curLevel.ToString());

            if(LevelScore[i] > 0)
            {
                Image scoreImage = levelObject.transform.GetChild(1).GetComponent<Image>();
                scoreImage.sprite = Resources.Load<Sprite>("star"+LevelScore[i]);
                scoreImage.color = new Color(1, 1, 1, 1);
            }

            if (LevelScore[i] < 0)
            {
                Button levelBtn = levelObject.transform.GetChild(0).GetComponent<Button>();
                levelBtn.interactable = false;
            }
        }
    }

}
