using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どの触手が攻撃するかを制御する
public class TentacleManager : MonoBehaviour
{
    struct Spwaner
    {
        public Transform position;
        public int index;
    }

    public static TentacleManager Instance = null;

    public GameObject[] prefabs;

    public List<Transform> spwanPositionList = new List<Transform>();

    public List<int> sufflePositionIndexList = new List<int>();
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
            sufflePositionIndexList.Add(i);
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

        for (int i = 0; i < sufflePositionIndexList.Count; i++)
        {
            temp1 = Random.Range(0, prefabs.Length);
            //今回選択されたトランスフォームのindexを取得
            selectIndex = sufflePositionIndexList[i];

            //そのトランスフォームが使われているか？
            if (!isSpawned[selectIndex])
            {
                GameObject obj = Instantiate(prefabs[temp1], spwanPositionList[selectIndex].position, Quaternion.identity);
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
        int temp = 0;
        for (int i = 0; i < sufflePositionIndexList.Count; i++)
        {
            index = Random.Range(0, sufflePositionIndexList.Count);
            temp = sufflePositionIndexList[i];
            sufflePositionIndexList[i] = sufflePositionIndexList[sufflePositionIndexList.Count - 1];
            sufflePositionIndexList[sufflePositionIndexList.Count - 1] = temp;
        }
    }
}
