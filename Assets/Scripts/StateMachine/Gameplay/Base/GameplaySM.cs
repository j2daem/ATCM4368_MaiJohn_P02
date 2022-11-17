using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySM : StateMachine
{
    private void Start()
    {
        ChangeState<PlayerState>();
    }
}
