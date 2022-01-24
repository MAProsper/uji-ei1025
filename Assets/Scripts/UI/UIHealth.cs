using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : BaseBehaviour
{
    public float hideDelay = 3f;
    EntityHealth entityHealth;
    Slider slider;

    void Start() {
        slider = GetComponentInChildren<Slider>();
        entityHealth = GetComponentInParent<EntityHealth>();
        if (hideDelay < 0) Show();
    }

    public void Show() {
        CancelInvoke("Hide");
        animator.SetBool("Visible", true);
        if (hideDelay >= 0) Invoke("Hide", hideDelay);
        slider.value = entityHealth.GetHealth() / entityHealth.healthMax;
    }

    public void Hide() {
        animator.SetBool("Visible", false);
    }

    void Update() {
        transform.LookAt(Camera.main.transform);
    }
}
