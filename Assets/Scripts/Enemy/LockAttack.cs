using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAttack : ShootAttack
{
    EntityMovement entityMovement;
    bool locked;

    protected override void Awake() {
        base.Awake();
        lineDealy = attackDelay;
        entityMovement = GetComponent<EntityMovement>();
    }

    public bool GetLocked() {
        return locked;
    }

    protected override void OnAttack(GameObject other)
    {
        if (GetLocked()) {
            base.OnAttack(other);
        } else {
            OnLock();
        }
    }

    protected virtual void OnLock() {
        locked = true;
        CancelInvoke("OnUnlock");
        attackLine.enabled = true;
        entityMovement.SetActive(false);
        Invoke("OnUnlock", attackDelay);
    }

    protected virtual void OnUnlock() {
        locked = false;
        CancelInvoke("OnUnlock");
        attackLine.enabled = false;
        entityMovement.SetActive(true);
        attackInput.Press();
    }
}
