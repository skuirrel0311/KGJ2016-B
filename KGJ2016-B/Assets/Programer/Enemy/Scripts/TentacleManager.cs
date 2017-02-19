using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どの触手が攻撃するかを制御する
public class TentacleManager : MonoBehaviour
{
    public List<TentacleContoller> tentacleList = new List<TentacleContoller>();

    void Start()
    {
        tentacleList.AddRange(GetComponentsInChildren<TentacleContoller>());

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        //どの職種が攻撃するか決定する
        TentacleContoller[] tentacles;
        tentacles = GetRandomTentacle(1);
        //攻撃する間隔
        WaitForSeconds wait = new WaitForSeconds(5.0f);

        while (true)
        {
            for (int i = 0; i < tentacles.Length; i++)
            {
                tentacles[i].Attack();
            }

            yield return wait;
        }
    }

    TentacleContoller[] GetRandomTentacle(int num)
    {
        TentacleContoller[] tentacles = new TentacleContoller[num];
        int index;
        
        for(int i = 0;i< tentacleList.Count;i++)
        {
            index = Random.Range(0, tentacleList.Count);
            Swap(tentacleList[index], tentacleList[tentacleList.Count - 1]);
        }

        for(int i = 0;i< tentacles.Length;i++)
        {
            tentacles[i] = tentacleList[i];
        }

        return tentacles;
    }

    void Swap(TentacleContoller tentacle1, TentacleContoller tentacle2)
    {
        TentacleContoller temp = tentacle1;

        tentacle1 = tentacle2;
        tentacle2 = temp;
    }
}
