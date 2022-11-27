using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerTurnState : GameplayState
{
    protected GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public override void Enter()
    {

    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }
}
