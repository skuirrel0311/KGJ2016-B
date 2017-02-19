using UnityEngine;
using UnityEngine.UI;

public class PlayerHpGauge : PointGauge
{

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeValue(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeValue(-1);
        }

        base.Update();
    }

    protected override void SetGaugeImage()
    {
        ////×を書く
        //for (int i = 0; i < maxValue; i++)
        //{
        //    if (i < value)
        //    {
        //        pointImages[i].sprite = pointImagePrefab.GetComponent<Image>().sprite;
        //    }
        //}
    }
}
