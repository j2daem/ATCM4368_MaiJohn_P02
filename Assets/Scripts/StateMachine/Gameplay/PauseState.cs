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

    private bool _paused;

    public override void Enter()
    {
        _primaryButton.Select();
        _pauseMenuPanel.SetActive(true);
        _paused = true;
    }

    public override void Exit()
    {
        _pauseMenuPanel.SetActive(false);
        _paused = false;
    }

    public void OnPressedBack()
    {
        StateMachine.RevertState();
    }

/*    public override void PauseGame(InputAction.CallbackContext context)
    {
        if (context.action.triggered && _paused)
        {
            StateMachine.RevertState();
        }

        else
        {
            StateMachine.ChangeState<PauseState>();
        }
    }*/

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
