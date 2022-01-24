using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : EntityHealth
{
    ManagerPlayer managerPlayer;

    void Start() {
        managerPlayer = Manager.Get<ManagerPlayer>();
        if (gameObject.tag == "Player") managerPlayer.Add(gameObject);
    }

    protected override void OnDeadEnter() {
        deadScore = 0;
        base.OnDeadEnter();
    }

    protected override void OnDeadExit()
    {
        if (gameObject.tag == "Player") managerPlayer.Remove(gameObject);
        base.OnDeadExit();
    }
}
