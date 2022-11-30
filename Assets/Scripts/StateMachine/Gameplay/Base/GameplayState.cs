using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameplaySM))]
public class GameplayState : State
{
    protected GameplaySM StateMachine { get; private set; }
    protected GameManager GameManager;

    private void Awake()
    {
        StateMachine = GetComponent<GameplaySM>();
        GameManager = FindObjectOfType<GameManager>();  
    }

    public virtual void PauseGame (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StateMachine.ChangeState<PauseState>();
        }
    }
}
