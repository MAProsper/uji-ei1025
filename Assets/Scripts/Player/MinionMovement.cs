using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMovement : FollowMovement
{
    EntityHealth minionHealth;
    int floorLayer;

    protected override void Awake()
    {
        base.Awake();
        minionHealth = GetComponent<EntityHealth>();
        floorLayer = LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        if (!GetActive() && other.layer == floorLayer) minionHealth.TakeDamage(minionHealth.GetHealth());
    }

    public void Jump(float force) {
        SetActive(false);
        minionHealth.TakeDamage(force);
        body.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
