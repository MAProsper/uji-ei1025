using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityUtility
{
    public static GameObject Closet(GameObject target, List<GameObject> others) {
        return others.Count == 0 ? target : others.Aggregate(others[0], (closet, other) => IsCloserThan(target, other, closet) ? other : closet);
    }

    public static float Distance(GameObject a, GameObject b) {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    public static bool IsCloserThan(GameObject entity, GameObject target, GameObject other) {
        return Distance(entity, target) < Distance(entity, other);
    }

    public static void LookRotation(Rigidbody entity, Vector3 direction) {
        if (direction == Vector3.zero) return;
        Quaternion rotation = Quaternion.LookRotation(direction);
        entity.MoveRotation(rotation);
    }

    public static bool ExistsAnimatorParameter(Animator animator, string parameterType, string parameterName) {
        if (animator == null || !Enum.TryParse(parameterType, out AnimatorControllerParameterType type)) return false;
        return Array.Exists(animator.parameters, parameter => parameter.type == type && parameter.name == parameterName);
    }

    public static Vector3 Interpolate(GameObject entity, GameObject target, float factor) {
        return Vector3.Lerp(entity.transform.position, target.transform.position, factor);
    }

    public static GameObject Spawn(GameObject entity, GameObject point) {
        if (entity != ManagerResource.smoke) Spawn(ManagerResource.smoke, point);
        return MonoBehaviour.Instantiate(entity, point.transform.position, Quaternion.identity);
    }

    public static GameObject SpawnInChildren(GameObject entity, GameObject points) {
        int index = UnityEngine.Random.Range(0, points.transform.childCount);
        return Spawn(entity, points.transform.GetChild(index).gameObject);
    }
}
