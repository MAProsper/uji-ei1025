using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAttack : EntityAttack
{
    ManagerScore managerScore;
    public int startPlayers = 3;
    public GameObject spawnPoints;

    protected override void Awake() {
        base.Awake();
        attackLayer = LayerMask.NameToLayer("Player");
    }

    void Start() {
        managerScore = Manager.Get<ManagerScore>();
        for (int i = 0; i < startPlayers; i++) {
            EntityUtility.SpawnInChildren(ManagerResource.leader, spawnPoints);
        }
    }

    protected override void OnAttack(GameObject other) {
        EntityHealth entityHealth = other.GetComponent<EntityHealth>();
        managerScore.ScoreUpdate(-entityHealth.deadScore);
        EntityUtility.SpawnInChildren(other, spawnPoints);
    }

    new void Attack(GameObject other) {
        EntityHealth entityHealth = other.GetComponent<EntityHealth>();
        if (managerScore.GetScore() >= entityHealth.deadScore) base.Attack(other);
    }

    void FixedUpdate() {
        if (Input.GetButton("Spawn Leader")) Attack(ManagerResource.leader);
        if (Input.GetButton("Spawn Minion")) Attack(ManagerResource.minion);
    }
}
