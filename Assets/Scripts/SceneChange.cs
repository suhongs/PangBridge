using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public void LevelBtnClicked()
    {
        // 레벨 선택씬 -> 게임씬
        GameObject.Find("Canvas").GetComponent<LevelManager>().BtnClicked();
        FadeToLevel(2);
    }

    public void LevelFinished()
    {
        FadeToLevel(2);
    }

    public void FadeToLevel (int levelIndex)
    {
        // 씬 전환 함수 level 0=메인, 1=레벨 선택, 2=게임
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
