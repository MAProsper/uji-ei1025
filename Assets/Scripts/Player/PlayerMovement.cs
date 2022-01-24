using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    const int rayLength = 100;
    int floorMask;

    protected override void Awake()
    {
        base.Awake();
        floorMask = LayerMask.GetMask("Floor");
        SetActive(false);
    }
    
    protected override void VelocityUpdate() {
        velocity = Manager.main.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
    }

    protected override void LookingUpdate() {
        Ray camaraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camaraRay, out RaycastHit floorHit, rayLength, floorMask)) {
            looking = floorHit.point - transform.position;
            looking.y = 0f;
        }
    }
}
