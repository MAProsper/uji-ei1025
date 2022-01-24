using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDealy
{
    float timeDelay;
    float timeLast;

    public InputDealy(float timeDelay) {
        this.timeDelay = timeDelay;
        this.timeLast = 0;
    }

    public bool IsValid() {
        return (Time.fixedTime - timeLast) >= timeDelay;
    }

    public void Press() {
        timeLast = Time.fixedTime;
    }

    public bool PressIfValid() {
        bool valid = IsValid();
        if (valid) Press();
        return valid;
    }
}
