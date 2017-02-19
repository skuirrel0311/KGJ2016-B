using UnityEngine;
using UnityEngine.UI;

public class PointGauge : BaseGauge
{
    protected Image[] pointImages;
    [SerializeField]
    protected GameObject pointImagePrefab = null;

    [SerializeField]
    Vector3 origin = Vector3.zero;

    [SerializeField]
    Vector3 distance = Vector3.zero;

    public override void Start()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeValue(1);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeValue(-1);
        }
        base.Start();
        pointImages = new Image[value];
        for (int i = 0; i < value; i ++)
        {
            pointImages[i] = Instantiate(pointImagePrefab).GetComponent<Image>();
            pointImages[i].transform.parent = transform;
            pointImages[i].rectTransform.anchoredPosition3D = origin + (distance * i);
            pointImages[i].rectTransform.localScale = Vector3.one;
        }
    }
    public override void Update()
    {
        ChangeValue(4 - ScoreManager.score);
        base.Update();
    }

    protected override void SetGaugeImage()
    {
        for(int i = 0;i < maxValue;i++)
        {
            pointImages[i].enabled = i < value;
        }
    }
}
