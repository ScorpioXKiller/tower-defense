using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform _shotPoint;

    public int Price => _price;

    protected Gun gun;

    private void Update()
    {
        if(GetCloserTarget() != null)
        {
            LockAtTarget();

            if (gun.IsReady)
                gun.Shoot(_shotPoint, GetCloserTarget());
        }
    }

    private void LockAtTarget()
    {   
        var dirToTarget = GetCloserTarget().transform.position - transform.position;
        var angle = Mathf.Atan2(dirToTarget.y, dirToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public Transform GetCloserTarget()
    {
        Transform closerTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            float distanceToTarget = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToTarget < shortestDistance && distanceToTarget <= attackRadius)
            {
                closerTarget = enemy.transform;
                shortestDistance = distanceToTarget;
            }
        }
        return closerTarget;
    }
}
