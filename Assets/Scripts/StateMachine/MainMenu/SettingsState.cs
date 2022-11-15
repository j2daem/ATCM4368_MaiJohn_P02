using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsState : MainMenuState
{
    [SerializeField] int _settingsMenuIndex = 2;

    public override void Enter()
    {
        for (int i = 0; i < _settingsMenuIndex; i++)
        {
            StateMachine.MenuPanels[i].SetActive(false);
        }

        StateMachine.MenuPanels[_settingsMenuIndex].SetActive(true);
    }

    public override void Exit()
    {
        StateMachine.MenuPanels[_settingsMenuIndex].SetActive(false);
    }
}
