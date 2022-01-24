using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : BaseBehaviour
{
    public float healthMax = 100f;
    public float damageDelay = 0.5f;
    public float deadDealy = 2f;
    public int deadScore = 10;
    public AudioClip deadSound;
    protected AudioSource audioSource;
    protected InputDealy damageInput;
    protected UIHealth healthUI;
    bool deadAnimator;
    float health;

    protected override void Awake()
    {
        base.Awake();
        health = healthMax;
        audioSource = GetComponent<AudioSource>();
        damageInput = new InputDealy(damageDelay);
        healthUI = GetComponentInChildren<UIHealth>();
        deadAnimator = EntityUtility.ExistsAnimatorParameter(animator, "Trigger", "Dead");
    }

    public float GetHealth() {
        return health;
    }
    
    public void TakeDamage(float amount)
    {
        if (damageInput.PressIfValid()) {
            OnTakeDamage(amount);
        }
    }

    protected virtual void OnTakeDamage(float amount) {
        if (health > 0 && health <= amount) OnDeadEnter();
        health -= amount;
        healthUI?.Show();
    }

    protected virtual void OnDeadEnter() {
        Manager.Get<ManagerScore>().ScoreUpdate(deadScore);
        if (deadSound != null) audioSource.PlayOneShot(deadSound);
        if (TryGetComponent(out EntityAttack entityAttack)) entityAttack.enabled = false;
        GetComponent<EntityMovement>()?.SetActive(false);
        if (deadAnimator) {
            Invoke("OnDeadExit", deadDealy);
            animator.SetTrigger("Dead");
        } else {
            OnDeadExit();
        }
    }

    protected virtual void OnDeadExit() {
        EntityUtility.Spawn(ManagerResource.smoke, gameObject);
        Destroy(gameObject); 
    }
}
