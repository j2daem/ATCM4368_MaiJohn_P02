using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseState : GameplayState
{
    [SerializeField] GameObject _pauseMenuPanel;
    [SerializeField] Button _primaryButton;

    public override void Enter()
    {
        _primaryButton.Select();
        _pauseMenuPanel.SetActive(true);
    }

    public override void Exit()
    {
        _pauseMenuPanel.SetActive(false);
    }
}
