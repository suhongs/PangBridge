﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public static GameObject Instance;
    AudioSource bgm;

    //Singleton Pattern
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = GameObject.Find("BGM");
        DontDestroyOnLoad(gameObject);
    }

    public void BgmPlay()
    {
        if (Instance == null)
            bgm = gameObject.GetComponent<AudioSource>();
        else
            bgm = Instance.GetComponent<AudioSource>();
        bgm.enabled = true;
    }

    public void BgmStop()
    {
        if (Instance == null)
            bgm = gameObject.GetComponent<AudioSource>();
        else
            bgm = Instance.GetComponent<AudioSource>();
        bgm.enabled = false;
    }
}