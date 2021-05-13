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
    private bool isPressed;
    Vector3 originPos1;
    Vector3 originPos2;
    Vector3 newPos1;
    Vector3 newPos2;
    public Material glowMaterial;

    void Start()
    {
        isPressed = false;
        isGameStarted = true;
        defaultScale = transform.localScale;
        defaultPosition = transform.position;
        paneldefaultPosition = panel.transform.position;
        paneldefaultScale = panel.transform.localScale;
        originPos1 = transform.GetChild(0).position;
        originPos2 = transform.position;
        newPos1 = originPos1;
        newPos1.y += 0.3f;
        newPos2 = originPos2;
        newPos2.y -= 0.3f;

        panel.GetComponent<MeshRenderer>().material = glowMaterial;
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
                isPressed = false;
                transform.position = originPos2;
                transform.GetChild(0).position = originPos1;
                GetComponent<MeshRenderer>().material.color = Color.red;
                //transform.position = defaultPosition;
                //transform.localScale = defaultScale;
                panel.transform.position = paneldefaultPosition;
                panel.transform.localScale = paneldefaultScale;
                isGameStarted = true;
                if (panel.activeSelf == false)
                    panel.SetActive(true);
            }
            //defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Key" || collision.gameObject.tag=="Player")
        {
            if (!isPressed)
            {
                transform.GetChild(0).position = newPos1;
                transform.position = newPos2;
                GetComponent<MeshRenderer>().material.color = new Color(0.354135f, 0.7735849f, 0.1058206f, 1f);
                isPressed = true;
            }
            panel.SetActive(false);
        }
    }
}
