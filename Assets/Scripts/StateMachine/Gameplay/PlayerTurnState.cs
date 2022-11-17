using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : GameplayState
{
    private int _playerTurnCount = 0;

    public override void Enter()
    {
        _playerTurnCount++;
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }
}
