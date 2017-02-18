using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance = null;
    GameObject panel;

    void Awake()
    {
        if(Instance != null)
        {
            //自分とInstanceが違ったらシーンに２つ存在している
            Destroy(this);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        Transform canvas = GameObject.Find("Canvas").transform;
        panel = canvas.Find("Panel").gameObject;
    }

    void OnLevelWasLoaded()
    {
        Transform canvas = GameObject.Find("Canvas").transform;
        panel = canvas.Find("Panel").gameObject;
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public IEnumerator FadeOut(float duration)
    {
        panel.SetActive(true);
        float t = 0.0f;
        Color startColor = panel.GetComponent<Image>().color;
        
        while (true)
        {
            t += Time.deltaTime;

            panel.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, t / duration);

            if (t > duration) break;

            yield return null;
        }
    }

    public IEnumerator FadeIn(float duration)
    {
        panel.SetActive(true);
        float t = 0.0f;
        Color startColor = panel.GetComponent<Image>().color;

        while (true)
        {
            t += Time.deltaTime;

            panel.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, 1.0f - t / duration);

            if (t > duration) break;

            yield return null;
        }

    }
}
