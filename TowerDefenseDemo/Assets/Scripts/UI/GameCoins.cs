using UnityEngine;

public class GameCoins : GameElement
{
    public event System.Action OnValueChanged;

    [SerializeField] private int _coinsPerEnemy;

    private int _transaction;

    public override void OnEnemySpawned()
    {
        FirstEnemy.OnDie += CoinsCounter_OnDie;
    }

    private void CoinsCounter_OnDie()
    {
        Get(_coinsPerEnemy);
    }

    public void Spend()
    {
        CurrentValue -= _transaction;
        OnValueChanged?.Invoke();
    }

    public bool CanSpend(int transiction)
    {
        _transaction = transiction;
        return CurrentValue >= _transaction;
    }

    public void Get(int transaction)
    {
        _transaction = transaction;
        CurrentValue += _transaction;
        OnValueChanged?.Invoke();
    }

    private void OnDisable()
    {
        if (FirstEnemy != null)
        {
            FirstEnemy.OnDie -= CoinsCounter_OnDie;
        }
        else
            return;
    }
}

