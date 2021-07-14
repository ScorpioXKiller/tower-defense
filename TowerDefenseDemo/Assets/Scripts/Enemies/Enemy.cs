using UnityEngine;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public event System.Action OnReachedFinish;
    public event System.Action OnDie;

    [SerializeField] protected Health _health;
    [SerializeField] private PathBuilder _path;
    [SerializeField] private float speed;

    private List<GameObject> _pathCells = new List<GameObject>();

    private int _wayIndex;
    private readonly float _finishPoint = 0.2f;

    private bool IsAlive => _health.CurrentValue > 0;

    private bool IsReachedFinish => _wayIndex >= _pathCells.Count - 1;

    protected virtual void Start()
    {
        _wayIndex = 0;
        _path = FindObjectOfType<PathBuilder>();
        _pathCells = _path.GetPath();
    }

    protected virtual void Update()
    {
        MoveToTarget();
    }

    public void TakeDamage(int damage)
    {
        _health.CurrentValue -= damage;
        StartCoroutine(_health.UpdateBar(_health.CurrentValue + damage));
        
        if (!IsAlive)
            Die();
    }

    private void MoveToTarget()
    {
        var currentPath = new Vector3(_pathCells[_wayIndex].transform.position.x + 0.5f, _pathCells[_wayIndex].transform.position.y - 0.5f);

        Vector2 dir = currentPath - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentPath) < _finishPoint)
        {
            if (!IsReachedFinish)
                _wayIndex++;
            else
            {
                OnReachedFinish?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    private void Die()
    {
        OnDie?.Invoke();
        Destroy(gameObject, 0.2f);    
    }

    
}