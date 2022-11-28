using UnityEngine;
using UnityEngine.UI;

public class PlayerDrawCardsState : GameplayState
{
    [SerializeField] GameObject _playerTurnPanel;
    [SerializeField] Button _drawCardButton;

    public override void Enter()
    {
        Debug.Log("Current State: Player Draw Cards State");
        _playerTurnPanel.SetActive(true);
        _drawCardButton.interactable = true;
    }

    public override void Tick()
    {
        if (GameManager.CurrentHandSize >= GameManager.MaxHandSize)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        _drawCardButton.interactable = false;
        StateMachine.ChangeState<PlayerPlayCardsState>();
    }
}
