using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp : BaseBehaviour
{
    Text text;
    public GameObject[] entities;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponent<Text>();
        Show();
    }

    public void Show()
    {
        List<string> texts = new List<string>();
        
        foreach (GameObject entity in entities) {
            if (entity.TryGetComponent(out EntityHealth entityHealth)) {
                texts.Add($"{entity.name}: {entityHealth.deadScore}");
            }
        }

        text.text = string.Join("\n", texts);
    }
}
