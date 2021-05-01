using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public void StartBtnClicked()
    {
        // 메인씬 -> 레벨 선택씬
        FadeToLevel(1);
    }

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
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
