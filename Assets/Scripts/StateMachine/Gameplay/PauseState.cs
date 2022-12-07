using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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

    public void OnPressedBack()
    {
        StateMachine.RevertState();
    }

    public override void PauseGame(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            if (StateMachine.CurrentState is PauseState)
            {
                StateMachine.RevertState();
            }

            else
            {
                StateMachine.ChangeState<PauseState>();
            }
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
