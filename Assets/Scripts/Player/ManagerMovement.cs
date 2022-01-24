using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovement : EntityMovement 
{
    public float rotationSpeed = 72f;
    public float nearFactor = 0.5f;
    ManagerPlayer managerPlayer;

    void Start() {
        managerPlayer = Manager.Get<ManagerPlayer>();
    }

    protected override void MoveUpdate() {
        if (managerPlayer.target != null) {
            Vector3 nearTarget = EntityUtility.Interpolate(gameObject, managerPlayer.target, nearFactor);
            transform.position = Vector3.MoveTowards(transform.position, nearTarget, speed * Time.deltaTime);
        }
    }

    protected override void RotationUpdate()
    {
        transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Rotation") * rotationSpeed * Time.deltaTime, Vector3.up);
    }
}
