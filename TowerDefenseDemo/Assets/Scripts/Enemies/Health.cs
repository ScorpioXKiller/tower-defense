using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private Color _fullHealth;
    [SerializeField] private Color _nonHealth;
    [SerializeField] private Image _healthBar;

    public int MaxValue => _value;
    public int CurrentValue { get; set; }

    private void Start()
    {
        CurrentValue = MaxValue;
    }

    public IEnumerator UpdateBar(float currentHealth)
    {
        while (true)
        {
            currentHealth--;

            _healthBar.fillAmount = currentHealth / MaxValue;
            _healthBar.color = Color.Lerp(_nonHealth, _fullHealth, _healthBar.fillAmount);

            if (currentHealth <= CurrentValue)
                break;

            yield return new WaitForSeconds(0.01f);
        }
    }


}
