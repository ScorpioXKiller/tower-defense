using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Text _livesText;
    [SerializeField] private GameLives _lives;

    private void Start()
    {
        UpdateLivesUI();
    }

    private void OnEnable()
    {
        _lives.OnValueChanged += UpdateLivesUI;
    }

    private void UpdateLivesUI()
    {
        _livesText.text = "Lives: " + _lives.CurrentValue.ToString();
    }

    private void OnDisable()
    {
        _lives.OnValueChanged -= UpdateLivesUI;
    }

}
