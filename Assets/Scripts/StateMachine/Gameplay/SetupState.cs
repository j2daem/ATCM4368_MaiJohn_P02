using UnityEngine;

public class SetupState : GameplayState
{
    private bool _activated;

    public override void Enter()
    {
        _activated = false;

        GameManager.LoadCardStats();
        GameManager.Damage = 0;
    }

    public override void Tick()
    {
        if (_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerDrawCardsState>();
        }
    }

    public override void Exit()
    {

    }
}
