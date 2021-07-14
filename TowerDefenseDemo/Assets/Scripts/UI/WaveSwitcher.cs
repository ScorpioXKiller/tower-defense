using UnityEngine;
using System.Collections;

public class WaveSwitcher : MonoBehaviour
{
    public event System.Action OnValueChanged;

    [SerializeField] private int _maxWaves;
    [SerializeField] private float _timeBetweenWaves;

    public int CurrentValue { get; private set; }

    public int MaxValue => _maxWaves;

    public bool IsStarted { get; private set; }

    private void Awake()
    {
        CurrentValue = 1;
        IsStarted = true;
    }

    public IEnumerator SwitchToNext()
    {
        IsStarted = false;
        yield return new WaitForSeconds(_timeBetweenWaves);

        if(CurrentValue < MaxValue)
        {
            CurrentValue++;
            IsStarted = true;
            OnValueChanged?.Invoke();
        }        
    }
}
