using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : BaseBehaviour
{
    Text text;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponent<Text>();
    }

    public void Show(int score)
    {
        text.text = score.ToString();
    }
}
