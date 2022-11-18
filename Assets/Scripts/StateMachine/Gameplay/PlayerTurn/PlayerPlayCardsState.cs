using UnityEngine;
using UnityEngine.UI;

public class PlayerPlayCardsState : GameplayState
{
    [SerializeField] GameObject _playerTurnPanel;
    [SerializeField] Button _playCardButton;
    [SerializeField] GameObject _selectionBlocker;

    private int _totalCardsSelected;

    private void Start()
    {
        _playCardButton.interactable = false;
        _selectionBlocker.SetActive(true);
    }

    private void OnEnable()
    {
        GameManager.CardsPlayed += InitiateExit;
    }

    private void OnDisable()
    {
        GameManager.CardsPlayed -= InitiateExit;
    }

    public override void Enter()
    {
        Debug.Log("Current State: Player Play Cards State");
        _playCardButton.interactable = true;
        _selectionBlocker.SetActive(false);
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        _playCardButton.interactable = false;
        _selectionBlocker.SetActive(true);
        _playerTurnPanel.SetActive(false);
        StateMachine.ChangeState<PlayerCardsEffectState>();
    }
    public void InitiateExit()
    {
        Exit();
    }
}
