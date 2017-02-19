using UnityEngine;
using UnityEngine.UI;

public class PlayerHpGauge : PointGauge
{

    public override void Update()
    {
        base.Update();
        ChangeValue(CarPlaramater.CarHp);
        Debug.Log(value);

        base.Update();
    }
}
