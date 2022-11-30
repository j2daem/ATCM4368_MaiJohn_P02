using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : GameplayState
{
    [SerializeField] UIManager uIManager;

    public override void Enter()
    {
        Debug.Log("Current State: Lose State");
        uIManager.DisplayLoseText();
    }
}
