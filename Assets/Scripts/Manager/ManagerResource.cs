using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerResource : MonoBehaviour
{
    public static GameObject smoke;
    public static GameObject leader;
    public static GameObject minion;

    void Awake() {
        smoke = Resources.Load<GameObject>("Effect/Smoke");
        leader = Resources.Load<GameObject>("Zombie/Zombie Leader");
        minion = Resources.Load<GameObject>("Zombie/Zombie Minion");
    }
}
