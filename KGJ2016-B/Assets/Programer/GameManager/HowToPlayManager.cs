﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayManager : BaseManager<TitleManager>
{

    //シーンの遷移が実行されているか？
    bool isChangeScene = false;
    public string sceneName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isChangeScene) return;
            isChangeScene = true;
            StartCoroutine(KKUtilities.ChangeScene(sceneName, 1.0f));
        }
    }
}
