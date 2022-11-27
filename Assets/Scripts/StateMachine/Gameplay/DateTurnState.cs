using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTurnState : GameplayState
{
    //private ActionType _currentAction;

    private void Awake()
    {
        
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        StateMachine.ChangeState<PlayerTurnState>();
    }

    public void ReactToPlayer()
    {
    }
}
