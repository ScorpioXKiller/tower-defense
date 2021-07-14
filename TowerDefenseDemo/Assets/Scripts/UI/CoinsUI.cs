using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private GameCoins _coins;

    private void Start()
    {
        UpdateCoinsUI();
    }

    private void OnEnable()
    {
        _coins.OnValueChanged += UpdateCoinsUI;
    }

    private void UpdateCoinsUI()
    {
        _coinsText.text = "Coins: " + _coins.CurrentValue.ToString();
    }

    private void OnDisable()
    {
        _coins.OnValueChanged -= UpdateCoinsUI;
    }
}
