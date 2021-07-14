using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private float attackRadius;

    public int Price => _price;

    protected Gun gun;

    private void Update()
    {
        if(GetClosestTarget() != null)
        {
            LockAtTarget();

            if (gun.IsReady)
                gun.Shoot(GetClosestTarget());
        }
    }

    private void LockAtTarget()
    {   
        var dirToTarget = GetClosestTarget().transform.position - transform.position;
        var angle = Mathf.Atan2(dirToTarget.y, dirToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public Transform GetClosestTarget()
    {
        Transform closestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            float distanceToTarget = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToTarget < shortestDistance && distanceToTarget <= attackRadius)
            {
                closestTarget = enemy.transform;
                shortestDistance = distanceToTarget;
            }
        }
        return closestTarget;
    }
}
