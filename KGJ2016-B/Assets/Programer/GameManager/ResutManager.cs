using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResutManager : BaseManager<TitleManager>
{
    //シーンの遷移が実行されているか？
    bool isChangeScene = false;
    public string sceneName = "";

    bool fade = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!fade)
        {
            StartCoroutine(FadeManager.Instance.FadeIn(0.5f));
            fade = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //すでにシーン遷移に入っていたら実行しない
            if (isChangeScene) return;
            isChangeScene = true;
            StartCoroutine(FadeManager.Instance.FadeOut(1.0f));
            StartCoroutine(KKUtilities.ChangeScene("Title", 1.0f));
        }
    }


}
