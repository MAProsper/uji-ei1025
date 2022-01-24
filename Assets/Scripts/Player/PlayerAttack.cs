using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : EntityAttack
{
    public float jumpForce = 15f;
    const float animatorDelay = 0.26f;
    GameObject jumpObject;

    protected override void Awake() {
        base.Awake();
        jumpObject = null;
    }

    protected override void OnTriggerStay(Collider collider) {
        Jump(collider.gameObject);
        base.OnTriggerStay(collider);
    }

    void Jump(GameObject other) {
        if (other.layer == gameObject.layer && other.tag != "Player" && Input.GetButton("Jump") && attackInput.PressIfValid()) OnJump(other);
    }

    void OnJump(GameObject other) {
        jumpObject = other;
        animator.SetTrigger("Attack");
        Invoke("SendJump", animatorDelay);
    }

    void SendJump() {
        audioSource.PlayOneShot(attackSound);
        jumpObject?.GetComponent<MinionMovement>().Jump(jumpForce);
    }
}
