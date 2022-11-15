using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class MainState : MainMenuState
{
    [SerializeField] int _mainMenuIndex = 0;

    public override void Enter()
    {
        for (int i = 0; i < _mainMenuIndex; i++)
        {
            StateMachine.MenuPanels[i].SetActive(false);
        }

        StateMachine.MenuPanels[_mainMenuIndex].SetActive(true);
    }

    public override void Exit()
    {
        StateMachine.MenuPanels[_mainMenuIndex].SetActive(false);
    }

    #region Main Menu Functions
    public void OnPressedStart()
    {
        StateMachine.ChangeState<StartState>();
    }

    public void OnPressedCredits()
    {
        StateMachine.ChangeState<CreditsState>();
    }

    public void OnPressedSettings()
    {
        StateMachine.ChangeState<SettingsState>();
    }

    public void OnPressedQuit()
    {
        StateMachine.ChangeState<QuitState>();
    }
    #endregion
}
