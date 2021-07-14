using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun
{
    [SerializeField] private int _damage;

    public override void ShootBehaviour(Transform target)
    {
        Vector3 shootDir = (target.transform.position - transform.position).normalized;
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, shootDir);
        if (raycast.transform != null)
        {
            IDamageable damageable = raycast.transform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(_damage);
                Debug.DrawLine(transform.position, target.transform.position, Color.white, 0.1f);
            }
        }
    }
}
