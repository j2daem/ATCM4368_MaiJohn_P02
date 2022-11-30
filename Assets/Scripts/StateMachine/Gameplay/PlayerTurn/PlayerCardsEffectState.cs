using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCardsEffectState : GameplayState
{
    [SerializeField] TextMeshProUGUI _playerCardEffects;
    [SerializeField] GameObject _positiveReactionSprite;
    [SerializeField] GameObject _negativeReactionSprite;
    [SerializeField] GameObject _neutralReactionSprite;
    [SerializeField] string _positiveReactionText = "Their health decreased by ";
    [SerializeField] string _negativeReactionText = "Their health increased by ";
    [SerializeField] string _neutralReactionText = "Their health changed by ";
    [SerializeField] float _reactionTurnLength = 1.5f;

    private string _reactionText;
    private string _reactionEnd;
    private int _damage;

    private void Start()
    {
        _playerCardEffects.gameObject.SetActive(false);
        _neutralReactionSprite.SetActive(true);
        _positiveReactionSprite.SetActive(false);
        _negativeReactionSprite.SetActive(false);
    }

    public override void Enter()
    {
        Debug.Log("Current State: Player Cards Effect State");

        _playerCardEffects.gameObject.SetActive(true);

        _damage = GameManager.CalculateDamage();
        GameManager._enemyHealth.UpdateHealth(_damage);

        Debug.Log(_damage.ToString() + " damage dealt!");

        SetReactions();
        
        StartCoroutine(TurnLength());
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
        _playerCardEffects.gameObject.SetActive(false);
        _neutralReactionSprite.SetActive(true);
        _positiveReactionSprite.SetActive(false);
        _negativeReactionSprite.SetActive(false);
    }

    private void SetReactions()
    {
        if (_damage > 0)
        {
            _reactionText = _positiveReactionText;
            _reactionEnd = "!";
            _positiveReactionSprite.SetActive(true);
            _negativeReactionSprite.SetActive(false);
            _neutralReactionSprite.SetActive(false);
        }

        else if (_damage < 0)
        {
            _reactionText = _negativeReactionText;
            _reactionEnd = "...";
            _negativeReactionSprite.SetActive(true);
            _positiveReactionSprite.SetActive(false);
            _neutralReactionSprite.SetActive(false);
        }

        else
        {
            _reactionText = _neutralReactionText;
            _reactionEnd = ".";
            _neutralReactionSprite.SetActive(true);
            _positiveReactionSprite.SetActive(false);
            _negativeReactionSprite.SetActive(false);
        }

        _playerCardEffects.text = _reactionText + _damage.ToString() + _reactionEnd;
    }

    IEnumerator TurnLength()
    {
        yield return new WaitForSeconds(_reactionTurnLength);

        if (GameManager._playerHealth.IsKilled)
        {
            StateMachine.ChangeState<LoseState>();
        }

        else if (GameManager._enemyHealth.IsKilled)
        {
            StateMachine.ChangeState<WinState>();
        }

        else
        {
            StateMachine.ChangeState<EnemyTurnState>();
        }
    }
}
