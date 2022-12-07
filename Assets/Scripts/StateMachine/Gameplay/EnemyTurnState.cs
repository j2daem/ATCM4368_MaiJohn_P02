using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyTurnState : GameplayState
{
    [SerializeField] AudioClip _positiveReactionSFX;
    [SerializeField] AudioClip _negativeReactionSFX;
    [SerializeField] string _positiveReactionText;
    [SerializeField] string _negativeReactionText;
    [SerializeField] string _neutralReactionText;
    [SerializeField] TextMeshProUGUI _enemyActionText;

    private List<Card> _enemyCards = new List<Card>();
    private List<Card> _cardsToPlay= new List<Card>();

    private ActionType _firstFavoredCard;
    private ActionType _secondFavoredCard;

    private int _accuracy = 1;

    #region Events
    public static event Action EnemyTurnBegan = delegate { };
    public static event Action EnemyTurnEnded = delegate { };
    #endregion

    [SerializeField] float _pauseDuration = 1.5f;

    private void Start()
    {
        _firstFavoredCard = (ActionType)UnityEngine.Random.Range(0,3);
        _secondFavoredCard = (ActionType)UnityEngine.Random.Range(0, 3);
        _enemyCards.Clear();

        _accuracy = 1;
}

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

    private void DrawCards()
    {
        int numberOfCardsToDraw = GameManager.MaxHandSize - _enemyCards.Count;

        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            Card selectedCard;

            if (GameManager._deck.Count > 0)
            {
                selectedCard = GameManager.ChooseRandomCard();
                _enemyCards.Add(selectedCard);
                GameManager._deck.Remove(selectedCard);
            }

            else
            {
                GameManager.ShuffleInDiscardDeck();
                selectedCard = GameManager.ChooseRandomCard();
                _enemyCards.Add(selectedCard);
            }
        }

        Debug.Log("Enemy has " + _enemyCards.Count.ToString() + " cards.");
    }

    private void ChooseCards()
    {
        for (int i = 0; i < GameManager.NumCardsToPlay; i++)
        {
            //Debug.Log(i.ToString());

            for (int j = 0; j < _enemyCards.Count; j++)
            {
                if (_enemyCards[j].CardAction == _firstFavoredCard)
                {
                    _cardsToPlay.Add(_enemyCards[j]);
                    _enemyCards.Remove(_enemyCards[j]);
                    break;
                }

                else if (_enemyCards[j].CardAction == _secondFavoredCard)
                {
                    _cardsToPlay.Add(_enemyCards[j]);
                    _enemyCards.Remove(_enemyCards[j]);
                    break;
                }

                else
                {
                    int randomIndex = UnityEngine.Random.Range(0, _enemyCards.Count - 1);

                    _cardsToPlay.Add(_enemyCards[randomIndex]);
                    _enemyCards.Remove(_enemyCards[randomIndex]);
                    break;
                }
            }
        }
    }

    private void PlayCards()
    {
        ActionType firstCardAction = _cardsToPlay[0].CardAction;
        int firstCardEnumIndex = (int)firstCardAction;

        ActionType secondCardAction = _cardsToPlay[1].CardAction;
        int secondCardEnumIndex = (int)secondCardAction;

        int damage = GameManager._cardStats[firstCardEnumIndex] * GameManager._cardStats[secondCardEnumIndex];

        if (damage > 0)
        {
            int randomChance = UnityEngine.Random.Range(0, 1);

            if (randomChance > 0)
            {
                _firstFavoredCard = _cardsToPlay[0].CardAction;
                _secondFavoredCard = _cardsToPlay[1].CardAction;
                return;
            }

            else
            {
                _firstFavoredCard = (ActionType)UnityEngine.Random.Range(0, 3);
                _secondFavoredCard = (ActionType)UnityEngine.Random.Range(0, 3);
            }
        }

        else
        {
            int randomMemory = UnityEngine.Random.Range(0, 2);

            if (randomMemory > 0)
            {
                _accuracy++;
            }
        }


        if (damage > 0)
        {
            _enemyActionText.text = _positiveReactionText;
            AudioHelper.PlayClip2D(_positiveReactionSFX, .65f);
        }

        else if (damage < 0)
        {
            _enemyActionText.text = _negativeReactionText;
            AudioHelper.PlayClip2D(_negativeReactionSFX, .65f);
        }

        Debug.Log("Enemy dealt " + damage.ToString() + " damage.");

        GameManager._playerHealth.UpdateHealth(damage);
        _cardsToPlay[0].MoveToDiscardDeck();
        _cardsToPlay[1].MoveToDiscardDeck();

        _cardsToPlay.Clear();
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        yield return new WaitForSeconds(pauseDuration);

        DrawCards();
        ChooseCards();
        PlayCards();

        //_enemyActionText.gameObject.SetActive(true);

        yield return new WaitForSeconds(pauseDuration);

        //_enemyActionText.gameObject.SetActive(false);

        // Enemy performs action
        EnemyTurnEnded?.Invoke();

        StateMachine.ChangeState<PlayerDrawCardsState>();
    }
}
