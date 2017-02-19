using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : BaseManager<TitleManager>
{
    //シーンの遷移が実行されているか？
    bool isChangeScene = false;
    public string[] sceneName;

    bool fade = false;

    // Use this for initialization
    void Start()
    {
        AudioManager.Instance.Play("MainBgm");
    }

    // Update is called once per frame
    void Update()
    {
        if (!fade)
        {
            StartCoroutine(FadeManager.Instance.FadeIn(0.5f));
            fade = true;
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    ChangeScene(sceneName[0]);
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ChangeScene(sceneName[1]);
        //}
    }

    void ChangeScene(string sceneName)
    {
        if (isChangeScene) return;
        isChangeScene = true;
        StartCoroutine(FadeManager.Instance.FadeOut(1.0f));
        StartCoroutine(KKUtilities.ChangeScene(sceneName, 1.0f));
    }
}
