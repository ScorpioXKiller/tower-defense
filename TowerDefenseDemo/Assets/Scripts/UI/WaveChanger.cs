using UnityEngine;

public class WaveChanger : MonoBehaviour
{
    public event System.Action OnValueChanged;

    [SerializeField] private int _maxWaves;

    public int CurrentValue { get; private set; }

    public int MaxValue => _maxWaves;

    private void Awake()
    {
        CurrentValue = 1;
    }

    public void SwitchToNext()
    {
        if(CurrentValue < MaxValue)
        {
            CurrentValue++;
            OnValueChanged?.Invoke();
        }
        
    }
}
