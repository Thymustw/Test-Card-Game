using UnityEngine.UI;
using UnityEngine;

public class RunBar
{
    public Image Bar, Pos;
    public float Current, Speed, MaxDist;
    public bool IsArrivedDist;

    public RunBar(Image bar, Image pos, float current, float speed, float maxDist, bool isArrivedDist)
    {
        Bar = bar;
        Pos = pos;
        Current = current;
        Speed = speed;
        MaxDist = maxDist;
        IsArrivedDist = isArrivedDist;
    }

    /// <summary> Update the instance of run status. </summary>
    public void Run()
    {
        Current += Speed * Time.deltaTime;
        Bar.fillAmount = Current / MaxDist;

        RectTransform rectTemp = Bar.GetComponent<RectTransform>();
                
        float barWidth = rectTemp.rect.width;
        float xPos = Bar.fillAmount * barWidth - (barWidth / 2);

        Pos.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, Pos.GetComponent<RectTransform>().anchoredPosition.y);

        if(Bar.fillAmount == 1)
            IsArrivedDist = true;
    }
}
