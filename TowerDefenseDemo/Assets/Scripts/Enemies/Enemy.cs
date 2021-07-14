using UnityEngine;

[RequireComponent(typeof(Navigator))] 
public abstract class Enemy : MonoBehaviour, IDamageable
{
    public event System.Action OnReachedTarget;
    public event System.Action OnDied;

    [SerializeField] protected Health _health;
    [SerializeField] private float _speed;

    private Navigator _navigator;

    private bool IsAlive => _health.CurrentValue > 0;

    private void Awake()
    {
        _navigator = GetComponent<Navigator>();
    }

    protected virtual void Start()
    {
        _navigator.Init();
    }

    protected virtual void Update()
    {
        MoveToTarget();
    }

    public void TakeDamage(int damage)
    {
        _health.CurrentValue -= damage;
        StartCoroutine(_health.UpdateBarStatus(_health.CurrentValue + damage));
        
        if (!IsAlive)
            Die();
    }

    private void MoveToTarget()
    {
        transform.Translate(_navigator.GetDirectionToTarget().directionToTarget * _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _navigator.GetDirectionToTarget().currentPath) < _navigator.TargetPoint)
        {
            if (!_navigator.IsTargetReached)
                _navigator.CurrentWayIndex++;

            else
            {
                OnReachedTarget?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    private void Die()
    {     
        Destroy(gameObject, 0.2f);
        OnDied?.Invoke();
    }
}