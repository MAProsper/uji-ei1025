using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : EntityAttack
{
    public float lineDealy = 0.1f;
    protected ParticleSystem attackParticle;
    protected LineRenderer attackLine;

    protected override void Awake()
    {
        base.Awake();
        attackLine = GetComponentInChildren<LineRenderer>();
        attackParticle = GetComponentInChildren<ParticleSystem>();
    }

    protected override void OnAttack(GameObject other)
    {
        base.OnAttack(other);
        attackParticle?.Play();
        attackLine.enabled = true;
        Invoke("HideLine", lineDealy);
    }

    void HideLine() {
        attackLine.enabled = false;
    }
}
