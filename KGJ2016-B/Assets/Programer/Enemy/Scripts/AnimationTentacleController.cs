using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTentacleController : TentacleContoller
{
    float limitTime = 3.5f * 3.0f;

    public override void Start()
    {
        Vector3 startPosition = transform.position;
        startPosition.y = -1.0f;

        transform.position = startPosition;
    }

    public override void Update()
    {
        limitTime -= Time.deltaTime;

        if(limitTime <= 0.0f)
        {
            Fade();
        }
    }

    protected void Fade()
    {
        Destroy(gameObject);
    }

    public override void Attack()
    {
    }

    public override void HitFloor(string partName, Collider col)
    {
    }
}
