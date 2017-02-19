using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlaramater : MonoBehaviour {
    public static int CarHp;
    public bool Isdamaged = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CarHp <= 0)
        {

        }
        if (Isdamaged)
        {
            Isdamaged = false;
            CarHp--;
        }
	}
}
