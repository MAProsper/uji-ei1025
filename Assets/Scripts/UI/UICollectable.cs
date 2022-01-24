using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollectable : BaseBehaviour
{
    public float hideDelay = 3f;
    Text text;

    protected override void Awake() {
        base.Awake();
        text = GetComponent<Text>();
    }

    public void Show(string name) {
        text.text = name;
        CancelInvoke("Hide");
        animator.SetBool("Visible", true);
        Invoke("Hide", hideDelay);
    }

    public void Hide() {
        animator.SetBool("Visible", false);
    }
}
