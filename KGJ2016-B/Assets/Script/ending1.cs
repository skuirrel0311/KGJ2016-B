using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ScoreManager.score >= 4)
        {

            //new WaitForSeconds(2.0f);
            this.gameObject.SetActive(false);
        }
	}
}
