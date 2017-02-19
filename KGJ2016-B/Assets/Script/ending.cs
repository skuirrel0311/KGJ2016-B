using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ScoreManager.score >= 4)
        {
          
            //new WaitForSeconds(2.0f);
            this.gameObject.transform.position += new Vector3(0, 0.5f, 0);
        }
	}
}
