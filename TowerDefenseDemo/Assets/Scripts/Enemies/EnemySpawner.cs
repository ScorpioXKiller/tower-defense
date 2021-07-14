using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event System.Action OnEnemySpawned;

    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _startSpawnCount;

    [SerializeField] private WaveSwitcher _wave;
    [SerializeField] private Enemy[] _enemyTypes;
    [SerializeField] private PathBuilder _path;

    private readonly List<Enemy> _enemies = new List<Enemy>();

    private int _spawnCount = 0;
    private readonly int _spawnCountToAdd = 10;
    private float _currentTime;

    private readonly float offset = 0.5f;

    private void Start()
    {
        _currentTime = _timeToSpawn;
    }

    private void Update()
    {
        CleanEnemyList();

        if (_timeToSpawn <= 0 && _wave.IsStarted)
        {
            if (_spawnCount < _startSpawnCount)
            {
                _enemies.Add(SpawnEnemy());
                OnEnemySpawned?.Invoke();
                _timeToSpawn = _currentTime;
            }

            else
            {               
                if ( _enemies.Count == 0 && _wave.CurrentValue < _wave.MaxValue)
                {
                    _spawnCount = 0;
                    StartCoroutine(_wave.SwitchToNext());
                    _startSpawnCount += _spawnCountToAdd;
                }
            }
        }
        _timeToSpawn -= Time.deltaTime;
    }

    public List<Enemy> GetEnemyList()
    {
        if (_enemies.Count > 0)
        {
            return _enemies;
        }
        return null;
    }

    private Vector3 GetSpawnPointPosition()
    {
        var position = _path.FirstPathCell.transform.localPosition.normalized;       
        return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
    }

    private Enemy SpawnEnemy()
    {
        int enemyLevel = _wave.CurrentValue - 1;

        var startCellPos = _path.FirstPathCell.transform.localPosition + GetSpawnPointPosition();

        var enemy = Instantiate(_enemyTypes[enemyLevel], 
                                transform.position + new Vector3(-startCellPos.y + offset, -startCellPos.x - offset), 
                                Quaternion.identity, 
                                gameObject.transform);
        
        _spawnCount++;
        return enemy;
    }  

    private void CleanEnemyList()
    {
        if (_enemies.Count > 0)
        {
            int enemyIndex = 0;

            if (_enemies[enemyIndex] == null)
                _enemies.RemoveAt(enemyIndex);
        }
    }
}
