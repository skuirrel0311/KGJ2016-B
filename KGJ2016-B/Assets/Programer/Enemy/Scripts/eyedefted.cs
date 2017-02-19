using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyedefted : MonoBehaviour {
    public bool Isattackd;
    public GameObject dead;
    bool doonce = false;
    bool particleonse = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Isattackd)
        {
            this.gameObject.transform.localScale = this.gameObject.transform.localScale - new Vector3(0, 0.1f, 0);
            if (!particleonse)
            {
                Instantiate(dead, transform.position,Quaternion.EulerAngles(-90.0f, 0, 0));
                particleonse = true;
            }
        }
        if(this.gameObject.transform.localScale.y <= 0.0f)
        {
            if(!doonce)
            {
                doonce = true;
                ScoreManager.score++;
            }
            Debug.Log("!");
            DestroyObject(this.gameObject);
        }
    }
}
