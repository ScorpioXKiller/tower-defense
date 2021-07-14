using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Gun
{
    [SerializeField] private Projectile _projectile;

    public override void ShootBehaviour(Transform target)
    {
        if (target == null) return;

        StartCoroutine(Delay());
        var projectile = Instantiate(_projectile, transform.position, Quaternion.identity, transform.parent);

        if(projectile != null)
            projectile.DetectTarget(target);

    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
