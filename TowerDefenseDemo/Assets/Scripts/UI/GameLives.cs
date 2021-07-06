using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLives : MonoBehaviour
{
    public event System.Action OnValueChanged;

    [SerializeField] private int _startValue;

    private int _value;

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

    public void TakeAway()
    {
        if(CurrentValue > 1)
        {
            CurrentValue--;
            OnValueChanged?.Invoke();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}