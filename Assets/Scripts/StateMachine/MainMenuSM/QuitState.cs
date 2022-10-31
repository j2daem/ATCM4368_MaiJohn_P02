using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitState : MainMenuState
{
    [SerializeField] int _quitMenuIndex = 3;

    public override void Enter()
    {
        for (int i = 0; i < _quitMenuIndex; i++)
        {
            StateMachine.MenuPanels[i].SetActive(false);
        }

        StateMachine.MenuPanels[_quitMenuIndex].SetActive(true);
    }

    public override void Exit()
    {
        StateMachine.MenuPanels[_quitMenuIndex].SetActive(false);
    }

    public void OnPressedQuit()
    {
        Application.Quit();
    }
}
