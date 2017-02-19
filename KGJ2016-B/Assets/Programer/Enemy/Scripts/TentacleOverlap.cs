using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleOverlap : MonoBehaviour
{
    TentacleContoller controller;
    [SerializeField]
    string partName;

    void Start()
    {
        controller = GetComponentInParent<TentacleContoller>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Floor" && col.gameObject.tag != "Player") return;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Floor") return;

        controller.HitFloor(partName, col);
    }
}
