using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Action
{
    nod,
    laugh,
    //smile,
    frown
}

public class PlayerState : GameplayState
{
    [SerializeField] GameObject _playerTurnPanel;
    [SerializeField] Button _primaryButton;

    private Action _currentAction;
    public Action CurrentAction => _currentAction;

    public override void Enter()
    {
        _playerTurnPanel.SetActive(true);
        _primaryButton.Select();
    }

    public override void Exit()
    {
        _playerTurnPanel.SetActive(false);
        StateMachine.ChangeState<DateState>();
    }

    public void ChooseAction(string action)
    {
        _currentAction = (Action)Enum.Parse(typeof(Action), action, true);

        Exit();
    }
}
