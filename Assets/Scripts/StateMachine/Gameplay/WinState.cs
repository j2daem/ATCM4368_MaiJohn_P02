using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : GameplayState
{
    [SerializeField] UIManager uIManager;

    public override void Enter()
    {
        Debug.Log("Current State: Win State");
        uIManager.DisplayWinText();
    }
}
