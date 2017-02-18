using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collider)
        {
        if (collider.gameObject.tag == "Finish")
        {
            //if(flag){
            //やられ処理
            //}
            //else{//攻撃処理 }
            DestroyObject(collider.gameObject);
            //
        }
    }
}
