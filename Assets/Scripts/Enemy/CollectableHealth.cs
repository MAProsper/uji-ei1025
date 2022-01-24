using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHealth : EntityHealth
{
    protected override void OnDeadEnter()
    {
        deadDealy = 0f;
        Manager.Get<ManagerScore>().CollectibleUpdate(gameObject.name);
        base.OnDeadEnter();
    }
}
