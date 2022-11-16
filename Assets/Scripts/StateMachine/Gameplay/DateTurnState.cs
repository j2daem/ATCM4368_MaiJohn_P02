using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTurnState : GameplayState
{
    private Actions _currentAction;
    private Topics _currentTopic;

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
