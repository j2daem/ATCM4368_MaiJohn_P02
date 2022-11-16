using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Actions
{
    chat,
    flirt,
    joke,
    insult
}

public enum Topics
{
    topic1,
    topic2,
    topic3,
    topic4
}

public class PlayerTurnState : GameplayState
{
    [SerializeField] GameObject _playerTurnPanel;
    [SerializeField] Button[] _actionButtons;
    [SerializeField] Button[] _topicButtons;
    [SerializeField] Button _primaryActionButton;
    [SerializeField] Button _primaryTopicButton;
    
    private PlayerInput _playerInput;

    private Actions _currentAction;
    private Topics _currentTopic;

    public Actions CurrentAction => _currentAction;
    public Topics CurrentTopic => _currentTopic;


    public override void Enter()
    {

        _playerInput = FindObjectOfType<PlayerInput>();

        // Reveal player actions
        _playerTurnPanel.SetActive(true);

        EnableActionButtons(true);
        EnableTopicButtons(false);

        _primaryActionButton.Select();
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        // Hide player actions
        _playerTurnPanel.SetActive(false);
        StateMachine.ChangeState<DateTurnState>();
    }

    #region Player Turn Functions
    public void ChooseAction(string action)
    {
        _currentAction = (Actions)Enum.Parse(typeof(Actions), action, true);

        EnableActionButtons(false);
        EnableTopicButtons(true);

        _primaryTopicButton.Select();
    }

    public void ChooseTopic(string topic)
    {
        _currentTopic = (Topics)Enum.Parse(typeof(Topics), topic, true);

        Exit();
    }

    public void CancelAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            EnableTopicButtons(false);
            EnableActionButtons(true);

            _primaryActionButton.Select();
        }
    }

    public void EnableActionButtons(bool state)
    {
        for (int i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].interactable = state;
        }
    }

    public void EnableTopicButtons(bool state)
    {
        for (int i = 0; i < _topicButtons.Length; i++)
        {
            _topicButtons[i].interactable = state;
        }
    }
    #endregion


}
