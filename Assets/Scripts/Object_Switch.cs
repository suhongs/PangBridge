using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Switch : MonoBehaviour
{
    [SerializeField]
    GameObject panel; //사라지게 할 블럭
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private Vector3 paneldefaultPosition;
    private Vector3 paneldefaultScale;
    private bool isGameStarted;

    void Start()
    {
        isGameStarted = true;
        defaultScale = transform.localScale;
        defaultPosition = transform.position;
        paneldefaultPosition = panel.transform.position;
        paneldefaultScale = panel.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                isGameStarted = false;
                
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                transform.localScale = defaultScale;
                panel.transform.position = paneldefaultPosition;
                panel.transform.localScale = paneldefaultScale;
                isGameStarted = true;
                if (panel.activeSelf == false)
                    panel.SetActive(true);
            }
            defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Key" || collision.gameObject.tag=="Player")
        {
            panel.SetActive(false);
        }
    }
}
