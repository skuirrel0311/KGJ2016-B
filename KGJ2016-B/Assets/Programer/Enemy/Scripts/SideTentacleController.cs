using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTentacleController : AnimationTentacleController
{
    float positionY = 5.0f;
    [SerializeField]
    float stageSize = 50.0f;

    public override void Start()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);

        Vector3 startPosition = Vector3.Normalize(new Vector3(x, 0, z)) * stageSize;
        startPosition.y = positionY;

        transform.position = startPosition;

        Vector3 direction = Vector3.Normalize(Vector3.one * positionY - startPosition);
        
        transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0.0f);
    }
}
