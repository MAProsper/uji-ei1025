using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : BaseBehaviour
{
    const int minute = 60;
    Text text;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponent<Text>();
    }

    public void Show(float time)
    {
        int min = Mathf.FloorToInt(time / minute);
        int sec = Mathf.FloorToInt(time % minute);
        text.text = $"{min.ToString().PadLeft(2, '0')}:{sec.ToString().PadLeft(2, '0')}";
    }
}
