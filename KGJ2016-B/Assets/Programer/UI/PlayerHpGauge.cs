﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerHpGauge : PointGauge
{
    [SerializeField]
    Image batten = null;

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeValue(1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeValue(-1);
        }

        base.Update();
    }

    protected override void SetGaugeImage()
    {
        //×を書く
        for (int i = 0; i < maxValue; i++)
        {
            if (i >= value)
            {
                pointImages[i].sprite = batten.sprite;
            }
            else
            {
                pointImages[i].sprite = pointImagePrefab.GetComponent<Image>().sprite;
            }
        }
    }
}
