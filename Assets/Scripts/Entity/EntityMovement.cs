using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : BaseBehaviour
{
    public float speed = 6f;
    protected Rigidbody body;
    protected Vector3 velocity;
    protected Vector3 looking;
    EntityHealth entityHealth;
    Vector3 lastLooking;
    bool speedAnimator;
    bool active;

    protected override void Awake() {
        base.Awake();
        active = true;
        velocity = Vector3.zero;
        looking = Random.insideUnitSphere;
        looking.y = 0f;
        
        body = GetComponent<Rigidbody>();
        entityHealth = GetComponent<EntityHealth>();
        speedAnimator = EntityUtility.ExistsAnimatorParameter(animator, "Float", "Speed");
    }

    public virtual void SetActive(bool active) {
        if (!active || entityHealth.GetHealth() > 0) {
            this.active = active;
        }
    }

    public bool GetActive() {
        return active;
    }

    protected virtual void VelocityUpdate() {
        velocity = Vector3.zero;
    }

    protected virtual void MoveUpdate() {
        body.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    protected virtual void LookingUpdate() {
    }

    protected virtual void RotationUpdate() {
        EntityUtility.LookRotation(body, looking);
    }

    protected virtual void AnimatorUpdate()
    {
        if (speedAnimator) {
            float speed = velocity.magnitude / this.speed;
            if (Vector3.Angle(velocity, looking) > 90) speed *= -1;
            animator.SetFloat("Speed", speed);
        }
    }

    protected virtual void FixedUpdate() {
        if (active) {
            VelocityUpdate();
            MoveUpdate();
        } else {
            velocity = Vector3.zero;
        }

        if (active) {
            LookingUpdate();
        }

        RotationUpdate();
        
        AnimatorUpdate();
    }
}
