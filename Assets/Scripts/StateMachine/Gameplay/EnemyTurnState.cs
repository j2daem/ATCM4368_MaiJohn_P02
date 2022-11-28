using System;
using System.Collections;
using UnityEngine;

public class EnemyTurnState : GameplayState
{
    public static event Action EnemyTurnBegan = delegate { };
    public static event Action EnemyTurnEnded = delegate { };

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {

    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        yield return new WaitForSeconds(pauseDuration);

        // Enemy performs action
        EnemyTurnEnded?.Invoke();

        StateMachine.ChangeState<PlayerDrawCardsState>();
    }
}
