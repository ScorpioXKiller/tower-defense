using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _startSpawnCount;

    [SerializeField] private WaveChanger _wave;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private PathBuilder _path;

    private int _spawnCount = 0;
    private float _currentTime;

    private void Start()
    {
        _currentTime = _timeToSpawn;
    }

    private void Update()
    {
        if (_timeToSpawn <= 0)
        {
            if (_spawnCount < _startSpawnCount)
            {
                SpawnEnemy();
                _timeToSpawn = _currentTime;
            }
            else
            {
                if (EnemyCounter.EnemyKills == _startSpawnCount && _wave.CurrentValue < _wave.MaxValue)
                {
                    EnemyCounter.EnemyKills = 0;
                    _spawnCount = 0;
                    _wave.SwitchToNext();

                    _startSpawnCount += 10;
                }
                else
                    return;
            }
        }
        _timeToSpawn -= Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        int enemyType = _wave.CurrentValue - 1;

        Vector3 startCellPos = _path.FirstPathCell.transform.localPosition + new Vector3(-1, 0);
        Instantiate(_enemies[enemyType], transform.position + new Vector3(-startCellPos.y + 0.5f, -startCellPos.x - 0.5f), Quaternion.identity, gameObject.transform);
        _spawnCount++;
    }
}
