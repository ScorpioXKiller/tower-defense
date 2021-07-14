using System.Collections;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected float _reloadingTime;

    public bool IsReady { get; private set; }

    private void Start()
    {
        IsReady = true;
    }

    public abstract void ShootBehaviour(Transform target);

    public void Shoot(Transform target)
    {
        IsReady = false;
        StartCoroutine(CooldownShooting());

        ShootBehaviour(target);
    }  

    private IEnumerator CooldownShooting()
    {
        yield return new WaitForSeconds(_reloadingTime);
        IsReady = true;
    }
}

