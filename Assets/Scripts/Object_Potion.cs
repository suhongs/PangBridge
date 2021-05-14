using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Potion : MonoBehaviour
{
    private GameManager gm;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool counted;
    private bool isGameStarted;
    private AudioSource audiosource;


    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameStarted = true;
        counted = false;
        defaultScale = transform.localScale;
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                counted = false;
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.localScale = defaultScale;
                isGameStarted = true;
            }
            defaultPosition = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !counted)
        {
            counted = true;
            transform.localScale = new Vector3(0, 0, 0);
            Vector3 originalScale = other.gameObject.transform.localScale;
            other.gameObject.transform.localScale = new Vector3(originalScale.x * 0.5f, originalScale.y * 0.5f, originalScale.z * 0.5f);
            Vector3 originPosition = other.transform.localPosition;
            other.gameObject.transform.localPosition = new Vector3(originPosition.x, originPosition.y, 0);
            audiosource.Play();

        }
    }
}
