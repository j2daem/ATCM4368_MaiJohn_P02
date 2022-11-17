using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplaySM : StateMachine
{
    private void Start()
    {
        ChangeState<SetupState>();
    }
}
