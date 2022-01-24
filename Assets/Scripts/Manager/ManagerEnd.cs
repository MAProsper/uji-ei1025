using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnd : MonoBehaviour
{
    public string scene;
    InputDealy endInput;
    UITransition uiTransition;

    void Awake() {
        uiTransition = ManagerUI.Get<UITransition>();
        endInput = new InputDealy(uiTransition.sceneDelay);
    }

    void Update()
    {
        if (Input.GetButton("Cancel") && endInput.PressIfValid()) {
            if (scene.Length == 0) {
                Application.Quit();
            } else {
                uiTransition.Show(scene);
            }
        }
    }
}
