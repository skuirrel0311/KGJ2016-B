﻿using System.Collections;
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

    [SerializeField]
    GameObject[] others = null;

    GameObject player;

    public TentacleState state = TentacleState.StartUp;

    [SerializeField]
    float powar = 1000.0f;

    Coroutine coroutine;
    bool isAttacking;

    public int positionIndex;
    public bool isLive;
    public float startY = -4.46f;
    public float endY = -50.0f;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(StartUp());
    }
    public virtual void Update()
    {
        if(tip.transform.position.x > 500.0f || tip.transform.position.z > 500.0f)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator StartUp()
    {
        float t = 0.0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition;
        targetPosition.y = startY;

        while (true)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, targetPosition, t / 3.0f);
            if (t > 3.0f) break;
            yield return null;
        }

        Attack();
    }

    public virtual void Attack()
    {
        coroutine = StartCoroutine(Attacking());
        state = TentacleState.Attack;
    }

    IEnumerator Attacking()
    {
        isAttacking = true;
        Rigidbody[] bodys = new Rigidbody[others.Length + 1];
        float coefficient = 0.5f;

        bodys[0] = tip.GetComponent<Rigidbody>();
        for (int i = 1; i < bodys.Length; i++)
        {
            bodys[i] = others[i - 1].GetComponent<Rigidbody>();
        }

        // = tip.GetComponent<Rigidbody>();

        WaitForSeconds wait = new WaitForSeconds(0.7f);
        state = TentacleState.Attack;

        //倒したい方向を調べる
        Vector3 targetDirection;
        Vector3 cross;
        if (player != null)
            targetDirection = Vector3.Normalize(player.transform.position - tip.transform.position);
        else
            targetDirection = Vector3.Normalize(Vector3.zero - tip.transform.position);
        cross = Vector3.Cross(targetDirection, Vector3.up).normalized;
        coefficient = 0.0f;
        int patten = 0;

        while(true)
        {
            patten = Random.Range(0, 3);

            if (patten != 0)
            {
                coefficient = Random.Range(-0.5f, 0.5f);
                AddForce(bodys, cross * Time.deltaTime * powar * coefficient);
            }
            else
            {
                AddForce(bodys, targetDirection * Time.deltaTime * powar * 2.0f);
            }
            yield return wait;
        }
    }

    void AddForce(Rigidbody[] bodys, Vector3 powar)
    {
        for (int i = 0; i < bodys.Length; i++)
        {
            bodys[i].AddForce(powar);
        }
    }

    public virtual void HitFloor(string partName, Collider col)
    {
        if (partName != "tip") return;
        isAttacking = false;

        //先端が床に触れた
        StartCoroutine(FadeOut());
        state = TentacleState.FadeOut;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        TentacleManager.Instance.isSpawned[positionIndex] = false;

        float t = 0.0f;
        float limitTime = 2.0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition;
        targetPosition.y = endY;

        DesableRagDoll();

        while(true)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t / limitTime);
            if (t > limitTime) break;
            yield return null;
        }

        Destroy(gameObject);
    }

    void DesableRagDoll()
    {
        Rigidbody[] body = GetComponentsInChildren<Rigidbody>();

        for(int i = 0;i < body.Length;i++)
        {
            body[i].isKinematic = true;
        }
    }
}
