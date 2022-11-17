using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DateState : GameplayState
{
    [Header("References")]
    [SerializeField] Health _playerHealth;
    [SerializeField] Health _dateHealth;
    [SerializeField] GameObject _dateTurnPanel;
    [SerializeField] TextMeshProUGUI _dateText;

    [SerializeField] float _dateTurnLength = 2;
    [SerializeField] int _damageAmount = 1;

    private PlayerInput _playerInput;
    private PlayerState _playerState;
    private bool _aftermathShown;

    private Action _currentAction;
    public Action CurrentAction => _currentAction;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerState = FindObjectOfType<PlayerState>();
    }

    public override void Enter()
    {
        _dateTurnPanel.SetActive(true);
        _dateText.text = "...";
        _aftermathShown = false;

        StartCoroutine(TurnActionDelay());
    }

    public override void Exit()
    {
        _dateTurnPanel.SetActive(false);
        StateMachine.ChangeState<PlayerState>();
    }

    IEnumerator TurnActionDelay()
    {
        yield return new WaitForSeconds(_dateTurnLength);

        ChooseAction();
    }

    public void ChooseAction()
    {
        int i = Random.Range(0, Action.GetNames(typeof(Action)).Length - 1);
        _currentAction = (Action)i;

        _dateText.text = "Your date " + _currentAction.ToString() + "s.";
    }

    public void ShowAftermath(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!_aftermathShown)
            {
                CalculateActions();
            }
            
            else
            {
                Exit();
            }
        }
    }

    public void CalculateActions()
    {
        if ((_currentAction == Action.nod))
        {
            if (_playerState.CurrentAction == Action.laugh)
            {
                _dateHealth.DecreaseHealth(_damageAmount);
                _dateText.text = "They gained feelings!";
            }

            else if (_playerState.CurrentAction == Action.frown)
            {
                _dateHealth.DecreaseHealth(_damageAmount);
                _dateText.text = "You gained feelings...";
            }

            else
            {
                _dateText.text = "No one gained feelings.";
            }
        }

        else if ((_currentAction == Action.laugh))
        {
            if (_playerState.CurrentAction == Action.frown)
            {
                _dateHealth.DecreaseHealth(_damageAmount);
                _dateText.text = "They gained feelings!";
            }

            else if (_playerState.CurrentAction == Action.nod)
            {
                _dateHealth.DecreaseHealth(_damageAmount);
                _dateText.text = "You gained feelings...";
            }

            else
            {
                _dateText.text = "No one gained feelings.";
            }
        }

        else if ((_currentAction == Action.frown))
        {
            if (_playerState.CurrentAction == Action.nod)
            {
                _dateHealth.DecreaseHealth(_damageAmount);
                _dateText.text = "They gained feelings!";
            }

            else if (_playerState.CurrentAction == Action.laugh)
            {
                _dateHealth.DecreaseHealth(_damageAmount);
                _dateText.text = "You gained feelings...";
            }

            else
            {
                _dateText.text = "No one gained feelings.";
            }
        }

        _aftermathShown = true;
    }
}
