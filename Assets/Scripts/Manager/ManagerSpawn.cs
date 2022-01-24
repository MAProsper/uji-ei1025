using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : EntityAttack
{
    public GameObject entity;

    protected override void Awake()
    {
        base.Awake();
        attackLayer = entity.layer;
    }

    protected override void OnAttack(GameObject other) {
        EntityUtility.SpawnInChildren(other, gameObject);
    }

    void FixedUpdate() {
        Attack(entity);
    }
}
