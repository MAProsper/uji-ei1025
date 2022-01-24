using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTime : MonoBehaviour
{
    public float timeMax = 300f;
    float time;
    UITime timeUI;

    void Awake() {
        time = timeMax;
    }

    void Start() {
        timeUI = ManagerUI.Get<UITime>();
    }

    void Update()
    {
        if (time > 0 && time <= Time.deltaTime) OnTimeOut();
        time -= Time.deltaTime;
        timeUI.Show(Mathf.Max(0, time));
    }

    void OnTimeOut() {
        ManagerUI.Get<UIEnd>().Show();
    }

    public void SetTime(float time) {
        this.time = time;
    }

    public float GetTime()
    {
        return time;
    }
}