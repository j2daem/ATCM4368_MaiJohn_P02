using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerCardsEffectState : GameplayState
{
    [SerializeField] TextMeshProUGUI _playerCardEffects;
    [SerializeField] string _positiveReaction = "Their health decreased by ";
    [SerializeField] string _negativeReaction = "Their health increased by ";
    [SerializeField] string _neutralReaction = "Their health changed by ";
    [SerializeField] float _reactionTurnLength = 1.5f;

    private string _reactionText;
    private string _reactionEnd;

    private void Start()
    {
        _playerCardEffects.gameObject.SetActive(false);
    }

    public override void Enter()
    {
        Debug.Log("Current State: Player Cards Effect State");

        _playerCardEffects.gameObject.SetActive(true);
        GameManager.CalculateDamage();

        SetReactions();
        StartCoroutine(TurnLength());
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        _playerCardEffects.gameObject.SetActive(false);
        StateMachine.ChangeState<EnemyTurnState>();
    }

    private void SetReactions()
    {
        if (GameManager.Damage > 0)
        {
            _reactionText = _positiveReaction;
            _reactionEnd = "!";
        }

        else if (GameManager.Damage < 0)
        {
            _reactionText = _negativeReaction;
            _reactionEnd = "...";
        }

        else
        {
            _reactionText = _neutralReaction;
            _reactionEnd = ".";
        }

        _playerCardEffects.text = _reactionText + GameManager.Damage.ToString() + _reactionEnd;
    }

    IEnumerator TurnLength()
    {
        yield return new WaitForSeconds(_reactionTurnLength);
        StateMachine.ChangeState<EnemyTurnState>();
    }
}
