using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public event System.Action OnEnemySpawned;

    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _startSpawnCount;

    [SerializeField] private WaveChanger _wave;
    [SerializeField] private Enemy[] _enemyTypes;
    [SerializeField] private PathBuilder _path;

    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private int _spawnCount = 0;
    private float _currentTime;

    private void Start()
    {
        _currentTime = _timeToSpawn;
    }

    private void Update()
    {
        EnemyCleaning();

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
                    _startSpawnCount += 10;
                }
            }
        }
        _timeToSpawn -= Time.deltaTime;
    }

    public Enemy SpawnEnemy()
    {
        int enemyLevel = _wave.CurrentValue - 1;

        Vector3 startCellPos = _path.FirstPathCell.transform.localPosition + new Vector3(-1, 0);
        var enemy = Instantiate(_enemyTypes[enemyLevel], transform.position + new Vector3(-startCellPos.y + 0.5f, -startCellPos.x - 0.5f), Quaternion.identity, gameObject.transform);
        _spawnCount++;
        return enemy;
    }

    public List<Enemy> GetEnemyList()
    {
        if(_enemies.Count > 0)
        {
            return _enemies;
        }
        return null;
    }

    private void EnemyCleaning()
    {
        if (_enemies.Count > 0)
        {
            int enemyIndex = 0;

            if (_enemies[enemyIndex] == null)
                _enemies.RemoveAt(enemyIndex);
        }
    }
}
