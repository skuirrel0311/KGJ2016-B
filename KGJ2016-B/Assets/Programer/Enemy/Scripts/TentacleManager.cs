using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab = null;

    [SerializeField]
    List<Transform> startPositions = new List<Transform>();

    void Start()
    {
        startPositions.AddRange(GetComponentsInChildren<Transform>());
        Transform temp = startPositions.Find(n => n.Equals(transform));
        startPositions.Remove(temp);

        StartCoroutine(EnemyCreator());
    }
    
    IEnumerator EnemyCreator()
    {
        WaitForSeconds wait = new WaitForSeconds(5.0f);
        yield return new WaitForSeconds(1.0f);
        int index = Random.Range(0, startPositions.Count);
        Instantiate(enemyPrefab, startPositions[index].position, startPositions[index].rotation);
        while (true)
        {
            yield return wait;
            index = Random.Range(0, startPositions.Count);
            Instantiate(enemyPrefab, startPositions[index].position, startPositions[index].rotation);
        }
    }
}
