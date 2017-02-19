using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どの触手が攻撃するかを制御する
public class TentacleManager : MonoBehaviour
{
    public static TentacleManager Instance = null;

    public GameObject[] prefabs;

    public List<Transform> spwanPositionList = new List<Transform>();

    public List<Transform> sufflePositionList = new List<Transform>();
    public bool[] isSpawned;

    public float spawnInterbal;
    float time;

    void Awake()
    {
        if (Instance != null)
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

        for(int i = 0;i < spwanPositionList.Count;i++)
        {
            sufflePositionList.Add(spwanPositionList[i]);
        }

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
        InterbalSpawning(1);
    }

    void Spawn()
    {
        int temp1;
        int selectIndex = 0;
        SufflePositionList();

        for (int i = 0; i < sufflePositionList.Count; i++)
        {
            temp1 = Random.Range(0, prefabs.Length + 1);
            //今回選択されたトランスフォームのindexを取得
            selectIndex = GetListIndex(sufflePositionList[i]);

            //そのトランスフォームが使われているか？
            if (!isSpawned[selectIndex])
            {
                Debug.Log("i = " + i);
                GameObject obj = Instantiate(prefabs[temp1], sufflePositionList[i].position, Quaternion.identity);
                obj.GetComponent<TentacleContoller>().positionIndex = selectIndex;
                isSpawned[selectIndex] = true;
                return;
            }
        }

        //生成できなかった
    }

    //一定時間ごとにspawnNum本の触手が沸くバージョン
    void InterbalSpawning(int spawnNum)
    {
        time += Time.deltaTime;
        if (time > spawnInterbal)
        {
            for (int i = 0; i < spawnNum; i++)
            {
                Spawn();
            }
            time = 0f;
        }
    }
    void SufflePositionList()
    {
        int index = 0;
        for (int i = 0; i < spwanPositionList.Count; i++)
        {
            index = Random.Range(0, spwanPositionList.Count);
            Swap(spwanPositionList[index], spwanPositionList[spwanPositionList.Count - 1]);
        }
    }
    void Swap(Transform t1, Transform t2)
    {
        Transform temp = t1;

        t1 = t2;
        t2 = temp;
    }

    int GetListIndex(Transform transform)
    {
        return spwanPositionList.FindIndex(n => n.Equals(transform));
    }
}
