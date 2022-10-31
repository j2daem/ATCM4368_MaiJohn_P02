using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsState : MainMenuState
{
    [SerializeField] int _creditsMenuIndex = 1;

    public override void Enter()
    {
        for (int i = 0; i < _creditsMenuIndex; i++)
        {
            StateMachine.MenuPanels[i].SetActive(false);
        }

        StateMachine.MenuPanels[_creditsMenuIndex].SetActive(true);
    }

    public override void Exit()
    {
        StateMachine.MenuPanels[_creditsMenuIndex].SetActive(false);
    }
}
