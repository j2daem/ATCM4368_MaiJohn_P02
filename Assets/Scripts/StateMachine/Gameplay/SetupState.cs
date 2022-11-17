using UnityEngine;

public class SetupState : GameplayState
{
    private bool _activated;

    public override void Enter()
    {
        _activated = false;
    }

    public override void Tick()
    {
        if (_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }

    public override void Exit()
    {

    }
}
