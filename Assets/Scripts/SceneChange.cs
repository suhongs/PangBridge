using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    int level;

    public void LevelBtnClicked()
    {
        string level_s = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        Debug.Log(level_s);

        if (level_s == "1") level = 1;
        if (level_s == "2") level = 2;
        if (level_s == "3") level = 3;
        if (level_s == "4") level = 4;
        if (level_s == "5") level = 5;
        if (level_s == "6") level = 6;
        if (level_s == "7") level = 7;
        //if (level_s == "8") level = 8;
        //if (level_s == "9") level = 9;
        FadeToLevel(level + 1);
    }

    public void LevelFinished()
    {
        FadeToLevel(2);
    }

    public void FreeModeBtn()
    {
        FadeToLevel(-1);
    }


    public void menuBtnClicked()
    {
        FadeToLevel(1);
    }

    public void retryBtnClicked()
    {
        Scene scene = SceneManager.GetActiveScene();
        int currentScene = scene.buildIndex;
        FadeToLevel(currentScene);
    }

    public void nextBtnClicked()
    {
        Scene scene = SceneManager.GetActiveScene();
        int currentScene = scene.buildIndex;
        int nextScene = currentScene + 1;
        FadeToLevel(nextScene);
    }

    public void FadeToLevel (int levelIndex)
    {
        // 씬 전환 함수 level 0=메인, 1=레벨 선택, 2=게임
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if(levelToLoad == -1)
        {
            SceneManager.LoadScene("FreeMode");
        }
        else
            SceneManager.LoadScene(levelToLoad);
    }
}
