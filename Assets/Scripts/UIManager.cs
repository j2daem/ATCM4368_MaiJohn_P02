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
    [SerializeField] Health _dateHealth;
    [SerializeField] Slider _dateHealthBar;
    [SerializeField] TextMeshProUGUI _winText;
    [SerializeField] TextMeshProUGUI _loseText;
    //[SerializeField] Image _sliderFill;
    //[SerializeField] Color _hurtColor;


    private void Start()
    {
        _playerHealthBar.maxValue = _playerHealth.MaxHealth;
        _playerHealthBar.value = _playerHealth.MaxHealth;

        _dateHealthBar.maxValue = _dateHealth.MaxHealth;
        _dateHealthBar.value = _dateHealth.MaxHealth;
    }

    private void OnEnable()
    {
        _playerHealth.HealthUpdated += UpdatePlayerHealthBar;
        _dateHealth.HealthUpdated += UpdateBossHealthBar;
        _playerHealth.Killed += DisplayLoseText;
        _dateHealth.Killed += DisplayWinText;

    }

    private void OnDisable()
    {
        _playerHealth.HealthUpdated -= UpdatePlayerHealthBar;
        _dateHealth.HealthUpdated -= UpdatePlayerHealthBar;
        _playerHealth.Killed -= DisplayLoseText;
        _dateHealth.Killed -= DisplayWinText;
    }

    void UpdatePlayerHealthBar()
    {
        _playerHealthBar.value = _playerHealth.CurrentHealth;
    }

    void UpdateBossHealthBar()
    {
        _dateHealthBar.value = _dateHealth.CurrentHealth;
        /*if (_bossHealth.CurrentHealth <= _playerHealth.MaxHealth / 2)
        {
            _sliderFill.color = _hurtColor;
        }*/
    }

    void DisplayWinText()
    {
        _winText.enabled = true;
    }

    void DisplayLoseText()
    {
        _loseText.enabled = true;
    }
}
