using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private Transform _target;

    public void DetectTarget(Transform target) => _target = target;

    private void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
            MoveByTargetDirection();
    }

    public void MoveByTargetDirection()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distancePerFrame = _speed * Time.deltaTime;

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
