using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public string sceneName;
    public static int score;
    public int scoreM;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (score >= scoreM)
        {
            score = 0;
            StartCoroutine(KKUtilities.ChangeScene(sceneName, 1.0f));
        }
    }
}
