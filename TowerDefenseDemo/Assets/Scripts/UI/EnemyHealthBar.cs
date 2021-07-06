using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Color _fullHealth;
    [SerializeField] private Color _nonHealth;
    [SerializeField] private Image _bar;

    //private void Start()
    //{
    //    //_bar.color = _fullHealth;
    //    _enemy = FindObjectOfType<Enemy>();
    //    _enemy.OnDamaged += UpdateHealth;
    //}

    //private void Update()
    //{
    //    //UpdateHealth();
    //}

    //private void UpdateHealth()
    //{
    //    StartCoroutine(HealthBarUpdate(_enemy.CurrentHealth + _enemy.Damage));
    //    //if (_enemy.CurrentHealth > 0)
    //    //{
    //    //    _bar.fillAmount = _enemy.CurrentHealth / _enemy.MaxHealth;
    //    //    //_bar.fillAmount = _enemy.CurrentHealth / _enemy.MaxHealth;
    //    //    _bar.color = Color.Lerp(_nonHealth, _fullHealth, _bar.fillAmount);
    //    //}
    //}

    //private IEnumerator HealthBarUpdate(float currentHealth)
    //{
    //    while(true)
    //    {
    //        currentHealth--;

    //        _bar.fillAmount = currentHealth / _enemy.MaxHealth;
    //        _bar.color = Color.Lerp(_nonHealth, _fullHealth, _bar.fillAmount);

    //        if (currentHealth <= _enemy.CurrentHealth)
    //            break;

    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
        

    //private void OnDisable()
    //{
    //    _enemy.OnDamaged -= UpdateHealth;
    //}
}
