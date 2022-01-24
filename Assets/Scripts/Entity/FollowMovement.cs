using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMovement : EntityMovement
{
    public float nearFactor = 0.5f;
    protected NavMeshAgent navMeshAgent;
    protected GameObject target;
    ManagerPlayer managerPlayer;

    protected override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        target = gameObject;
    }

    protected virtual void Start() {
        managerPlayer = Manager.Get<ManagerPlayer>();
    }

    public override void SetActive(bool active) {
        base.SetActive(active);
        navMeshAgent.enabled = GetActive();
        //Para que no quede tan "sintético", deberíamos hacer que primero rotase poco a poco hasta encarar al enemigo, y luego se moviese
    }
    
    protected virtual void OnTriggerEnter(Collider collider) {
        GameObject other = collider.gameObject;
        if (other.tag == "Player") {
            target = other;
        }
    }

    protected virtual void TargetUpdate() {
        if (target == null) target = gameObject;

        if (target == gameObject) {
            target = EntityUtility.Closet(gameObject, managerPlayer.players);
        }
    }

    protected override void VelocityUpdate() {
        velocity = navMeshAgent.velocity;
    }

    protected override void MoveUpdate() {
        Vector3 nearTarget = transform.position;
        nearTarget = EntityUtility.Interpolate(gameObject, target, nearFactor);
        navMeshAgent.SetDestination(nearTarget);
    }

    protected override void LookingUpdate()
    {
        if (target != gameObject) {
            looking = target.transform.position - transform.position;
            looking.y = 0f;
        }
    }

    protected override void FixedUpdate()
    {
        TargetUpdate();
        base.FixedUpdate();
    }
}
