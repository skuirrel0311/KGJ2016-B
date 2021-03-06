﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleOverlap : MonoBehaviour
{
    TentacleContoller controller;
    [SerializeField]
    string partName;

    void Start()
    {
    }

    void Update()
    {
        if (controller == null)
        {
            controller = GetComponentInParent<TentacleContoller>();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player") return;
        Debug.Log("!");
        CarPlaramater.CarHp--;
        return;

    }

    public virtual void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Floor") return;
        if (partName == "other") return;

        controller = GetComponentInParent<TentacleContoller>();
        controller.HitFloor(partName, col);
    }
}
