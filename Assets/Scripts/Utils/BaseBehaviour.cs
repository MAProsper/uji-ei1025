using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    protected Animator animator;

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
    }
}
