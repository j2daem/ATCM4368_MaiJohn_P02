using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Health _playerHealth;
    [SerializeField] Slider _playerHealthBar;
    [SerializeField] Health _enemyHealth;
    [SerializeField] Slider _enemyHealthBar;
    [SerializeField] TextMeshProUGUI _winText;
    [SerializeField] TextMeshProUGUI _loseText;
    //[SerializeField] Image _sliderFill;
    //[SerializeField] Color _hurtColor;

    private void Start()
    {
        _playerHealthBar.maxValue = _playerHealth.MaxHealth;
        _playerHealthBar.value = _playerHealth.CurrentHealth;

        _enemyHealthBar.maxValue = _enemyHealth.MaxHealth;
        _enemyHealthBar.value = _enemyHealth.CurrentHealth;

        _winText.gameObject.SetActive(false);
        _loseText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _playerHealth.HealthUpdated += UpdatePlayerHealthBar;
        _enemyHealth.HealthUpdated += UpdateEnemyHealthBar;
        _playerHealth.Killed += DisplayLoseText;
        _enemyHealth.Killed += DisplayWinText;

    }

    private void OnDisable()
    {
        _playerHealth.HealthUpdated -= UpdatePlayerHealthBar;
        _enemyHealth.HealthUpdated -= UpdatePlayerHealthBar;
        _playerHealth.Killed -= DisplayLoseText;
        _enemyHealth.Killed -= DisplayWinText;
    }

    void UpdatePlayerHealthBar()
    {
        _playerHealthBar.value = _playerHealth.CurrentHealth;
    }

    void UpdateEnemyHealthBar()
    {
        _enemyHealthBar.value = _enemyHealth.CurrentHealth;
        /*if (_bossHealth.CurrentHealth <= _playerHealth.MaxHealth / 2)
        {
            _sliderFill.color = _hurtColor;
        }*/
    }

    public void DisplayWinText()
    {
        _winText.gameObject.SetActive(true);
    }

    public void DisplayLoseText()
    {
        _loseText.gameObject.SetActive(true);
    }
}
