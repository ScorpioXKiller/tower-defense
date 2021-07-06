using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    public event System.Action OnValueChanged;

    [SerializeField] private int _startValue;

    private int _value;
    private int _transaction;

    public int CurrentValue
    {
        get
        {
            return _value;
        }
        private set
        {
            _value = value;
        }
    }

    private void Awake()
    {
        _value = _startValue;
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
}

