using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHealth : EntityHealth
{
    protected override void OnDeadEnter()
    {
        deadDealy = 0f;
        Instantiate(ManagerResource.minion, transform.position, transform.rotation);
        base.OnDeadEnter();
    }

}
