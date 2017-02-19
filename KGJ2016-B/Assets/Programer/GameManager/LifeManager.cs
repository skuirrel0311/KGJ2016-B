using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : BaseManager<TitleManager>
{
    public int playerLife;
    bool[] dispPlayerLife;
    public int enemyLife;
    bool[] dispEnemyLife;

    //GameObject obj = GameObject.CreatePrimitive;
    // Use this for initialization
    void Start () {
        dispPlayerLife = new bool[playerLife];
        for (int i = 0; i < dispPlayerLife.Length; i++)
        {
            dispPlayerLife[i] = false;
        }
        dispEnemyLife = new bool[enemyLife];
        for (int i = 0; i < dispEnemyLife.Length; i++)
        {
            dispEnemyLife[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
