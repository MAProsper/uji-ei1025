using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : BaseBehaviour
{
    InputDealy startInput;
    UITransition transition;

    protected override void Awake()
    {
        base.Awake();
        transition = ManagerUI.Get<UITransition>();
        startInput = new InputDealy(transition.sceneDelay);
    }
    void FixedUpdate()
    {
        if (Input.anyKey && startInput.PressIfValid()) {
            transition.Show("Level");
        }
    }
}
