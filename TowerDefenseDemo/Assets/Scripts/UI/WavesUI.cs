using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    [SerializeField] private Text _wavesText;
    [SerializeField] private WaveChanger _wave;

    private void Start()
    {
        UpdateLivesUI();
    }

    private void OnEnable()
    {
        _wave.OnValueChanged += UpdateLivesUI;
    }

    private void UpdateLivesUI()
    {
        _wavesText.text = "Wave: " + _wave.CurrentValue.ToString();
    }

    private void OnDisable()
    {
        _wave.OnValueChanged -= UpdateLivesUI;
    }
}
