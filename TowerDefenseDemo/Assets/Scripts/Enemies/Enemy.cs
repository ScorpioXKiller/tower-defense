using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float speed;
    [SerializeField] protected Health _health;
    private CoinsCounter _coins;
    private GameLives _lives;

    private PathBuilder _path;
    private List<GameObject> _pathCells = new List<GameObject>();

    private int _wayIndex;
    private readonly float _finishPoint = 0.2f;

    public bool IsAlive => _health.CurrentValue > 0;

    protected virtual void Start()
    {
        _wayIndex = 0;
        _path = FindObjectOfType<PathBuilder>();
        _coins = FindObjectOfType<CoinsCounter>();
        _lives = FindObjectOfType<GameLives>();
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

    private void Die()
    {
        Destroy(gameObject, 0.2f);    
    }

    private void MoveToTarget()
    {
        var currentPath = new Vector3(_pathCells[_wayIndex].transform.position.x + 0.5f, _pathCells[_wayIndex].transform.position.y - 0.5f);

        Vector2 dir = currentPath - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    
        if(Vector2.Distance(transform.position, currentPath) < _finishPoint)
        {
            if (_wayIndex < _pathCells.Count - 1)
                _wayIndex++;
            else
            {
                _lives.TakeAway();
                Destroy(gameObject);
            }
                
        }
    }

    private void OnDestroy()
    {
        if (!IsAlive)
        {
            EnemyCounter.EnemyKills++;
            _coins.Get(20);
        }
            
    }
}