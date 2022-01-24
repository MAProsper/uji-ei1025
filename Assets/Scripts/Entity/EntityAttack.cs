using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : BaseBehaviour
{
    public float attackDelay = 1.75f;
    public float attackDamage = 10f;
    public int attackLayer = -1;
    public AudioClip attackSound;
    protected InputDealy attackInput;
    protected AudioSource audioSource;
    bool attackAnimator;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        attackInput = new InputDealy(attackDelay);
        attackAnimator = EntityUtility.ExistsAnimatorParameter(animator, "Trigger", "Attack");
    }

    protected virtual void OnTriggerStay(Collider collider)
    {
        if (!collider.isTrigger) {
            Attack(collider.gameObject);
        }
    }

    protected void Attack(GameObject other)
    {
        if (other.layer == attackLayer && attackInput.PressIfValid()) OnAttack(other);
    }

    protected virtual void OnAttack(GameObject other) {
        other.GetComponent<EntityHealth>()?.TakeDamage(attackDamage);
        if (attackSound != null) audioSource.PlayOneShot(attackSound);
        if (attackAnimator) animator.SetTrigger("Attack");
    }
}
