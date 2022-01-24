using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameObject main;

    void Awake() {
        main = gameObject;
    }
    
    public static T Get<T>() {
        return main.GetComponent<T>();
    }
}
