using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleContoller : MonoBehaviour
{
    [SerializeField]
    GameObject tip = null;

    GameObject player;

    [SerializeField]
    float powar = 1000.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(StartUp());
    }
    void Update()
    {
    }

    IEnumerator StartUp()
    {
        float t = 0.0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition;
        targetPosition.y = 1.0f;

        while(true)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, targetPosition, t / 3.0f);
            if (t > 3.0f) break;
            yield return null;
        }

        //倒したい方向を調べる
        Vector3 targetDirection;
        if (player != null)
            targetDirection = Vector3.Normalize(player.transform.position - tip.transform.position);
        else
            targetDirection = Vector3.Normalize(Vector3.zero - tip.transform.position);

        tip.GetComponent<Rigidbody>().AddForce(targetDirection * Time.deltaTime * powar);
    }
}
