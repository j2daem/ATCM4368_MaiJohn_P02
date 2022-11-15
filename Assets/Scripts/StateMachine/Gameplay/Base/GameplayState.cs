using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameplaySM))]
public class GameplayState : State
{
    protected GameplaySM StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = GetComponent<GameplaySM>();
    }
}
