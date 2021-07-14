using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GameElement : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private int _startValue;

    protected Enemy FirstEnemy
    {
        get
        {
            if (_enemies != null)
            {
                if(_enemies.Count > 0)
                    return _enemies[_enemies.Count - 1];
            }
            return null;
        }
    }

    private List<Enemy> _enemies;

    private int _value;

    public int CurrentValue
    {
        get
        {
            return _value;
        }
        protected set
        {
            _value = value;
        }
    }

    private void OnEnable()
    {
        _value = _startValue;
        _enemySpawner.OnEnemySpawned += UIElement_OnEnemySpawned;
    }

    public abstract void OnEnemySpawned();

    private void UIElement_OnEnemySpawned()
    {
        _enemies = _enemySpawner.GetEnemyList();
        OnEnemySpawned();
    }

    private void OnDisable()
    {
        _enemySpawner.OnEnemySpawned -= UIElement_OnEnemySpawned;
    }
}
