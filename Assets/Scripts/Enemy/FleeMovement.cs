using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeMovement : FollowMovement
{
    protected override void MoveUpdate() {
        base.MoveUpdate();
        Vector3 destination = navMeshAgent.destination - transform.position;
        navMeshAgent.SetDestination(transform.position - destination / Mathf.Pow(nearFactor, 2));
    }

    protected override void LookingUpdate() {
        base.LookingUpdate();

        if (target != gameObject) {
            looking = -looking;
        }
    }
}
