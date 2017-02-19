using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どの触手が攻撃するかを制御する
public class TentacleManager : MonoBehaviour
{
    public static TentacleManager Instance = null;

    public GameObject[] prefabs;
    
    List<Transform> spwanPositionList = new List<Transform>();
    public bool[] isSpawned;

    public float spawnInterbal;
    float time;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        spwanPositionList.AddRange(GetComponentsInChildren<Transform>());
        //自身をはずす
        spwanPositionList.Remove(spwanPositionList.Find(n => n.Equals(transform)));

        isSpawned = new bool[spwanPositionList.Count];
        for (int i = 0; i < isSpawned.Length; i++)
        {
            isSpawned[i] = false;
        }

        //最初にとりあえず何体か出しておく
        for (int i = 0; i < 3; i++)
        {
            Spawn();
        }
    }

    void Update()
    {
        InterbalSpawning();
        
    }

    void Spawn()
    {
        int temp;
        int temp1;
        while (true)
        {

            temp = Random.Range(0, spwanPositionList.Count);
            temp1 = Random.Range(0, prefabs.Length + 1);
            if (!isSpawned[temp])
            {
                GameObject obj = Instantiate(prefabs[temp1], spwanPositionList[temp].position, Quaternion.identity);
                obj.GetComponent<TentacleContoller>().positionIndex = temp;
                isSpawned[temp] = true;
                break;
            }
        }
    }

    //一定時間ごとに沸くバージョン
    void InterbalSpawning()
    {
        time += Time.deltaTime;
        if (time > spawnInterbal)
        {
            Spawn();
            time = 0f;
        }
    }
}
