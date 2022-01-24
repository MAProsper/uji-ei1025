using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITransition : BaseBehaviour
{
    public float sceneDelay = 1f;
    string scene;

    protected override void Awake() {
        base.Awake();
        scene = null;
    }

    public void Show(string name) {
        scene = name;
        animator.SetBool("Visible", true);
        Invoke("LoadScene", sceneDelay);
    }

    public void Hide() {
        animator.SetBool("Visible", false);
    }

    void LoadScene() {
        if (scene != null) {
            SceneManager.LoadScene(scene);
        }
    }
}
