using UnityEngine;

public class PlayerCardsEffectState : GameplayState
{
    [SerializeField] GameObject _playerReactionPanel;

    public override void Enter()
    {
        Debug.Log("Current State: Player Cards Effect State");
        _playerReactionPanel.SetActive(true);
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        _playerReactionPanel.SetActive(false);
        StateMachine.ChangeState<EnemyTurnState>();
    }
}
