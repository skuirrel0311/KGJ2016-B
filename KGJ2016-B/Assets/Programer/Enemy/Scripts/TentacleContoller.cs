using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TentacleState
{
    StartUp, Idle, Attack, FadeOut
}

public class TentacleContoller : MonoBehaviour
{
    [SerializeField]
    GameObject tip = null;

    GameObject player;

    public TentacleState state = TentacleState.StartUp;

    [SerializeField]
    float powar = 1000.0f;

    Coroutine coroutine;
    bool isAttacking;

    public int positionIndex;
    public bool isLive;

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

        while (true)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, targetPosition, t / 3.0f);
            if (t > 3.0f) break;
            yield return null;
        }

        Attack();
    }

    public void Attack()
    {
        coroutine = StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        isAttacking = true;
        Rigidbody body = tip.GetComponent<Rigidbody>();
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        state = TentacleState.Attack;

        //倒したい方向を調べる
        Vector3 targetDirection;
        if (player != null)
            targetDirection = Vector3.Normalize(player.transform.position - tip.transform.position);
        else
            targetDirection = Vector3.Normalize(Vector3.zero - tip.transform.position);

        tip.GetComponent<Rigidbody>().AddForce(targetDirection * Time.deltaTime * powar);

        yield return new WaitForSeconds(3.0f);

        yield return wait;

        Vector3 cross = Vector3.Cross(targetDirection, Vector3.up).normalized;
        body.AddForce(cross * Time.deltaTime * powar);

        yield return wait;

        body.AddForce(cross * -Time.deltaTime * powar);

        isAttacking = false;

    }

    public void HitFloor(string partName, Collider col)
    {
        if (partName != "tip") return;
        if(isAttacking)
        {
            StopCoroutine(coroutine);
            isAttacking = false;
        }

        //先端が床に触れた
        coroutine = StartCoroutine(FadeOut());
        state = TentacleState.FadeOut;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        TentacleManager.Instance.isSpawned[positionIndex] = false;
        Destroy(gameObject);
    }
}
