using System;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    chat,
    flirt,
    insult,
    joke
}

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("References")]
    [SerializeField] public List<Card> _deck = new List<Card>();
    [SerializeField] public Transform[] _cardSlots;
    [SerializeField] public Health _playerHealth;
    [SerializeField] public Health _enemyHealth;

    [Header("Settings")]
    [SerializeField] public int[] _cardStats;
    [SerializeField] int _numCardsToPlay = 2;

    private List<Card> _selectedCards = new List<Card>();
    private List<Card> _playedCards = new List<Card>();
    private List<Card> _discardDeck = new List<Card>();

    private int _currentHandSize;
    private int _maxHandSize;
    #endregion

    #region Getters/Setters
    public bool[] _availableCardSlots { get; set; }
    public List<Card> SelectedCards => _selectedCards;
    public List<Card> PlayedCards => _playedCards;
    public List<Card> DiscardDeck => _discardDeck;
    public int NumCardsToPlay => _numCardsToPlay;
    public int CurrentHandSize => _currentHandSize;
    public int MaxHandSize => _maxHandSize;
    public int HandIndex { get; set; }
    #endregion

    #region

    #endregion

    public event Action CardsPlayed = delegate { };

    private void Awake()
    {
        _availableCardSlots = new bool[_cardSlots.Length];

        for (int i = 0; i < _availableCardSlots.Length; i++)
        {
            _availableCardSlots[i] = true;
        }

        _currentHandSize = 0;
        _maxHandSize = _cardSlots.Length;
    }

    public void DrawCard()
    {
        _currentHandSize = VerifyCurrentHandSize();

        if (_currentHandSize < _maxHandSize)
        {
            if (_deck.Count > 0)
            {
                Card selectedCard = ChooseRandomCard();

                for (int i = 0; i < _availableCardSlots.Length; i++)
                {
                    if (_availableCardSlots[i])
                    {
                        //Debug.Log(selectedCard.CardName.text + " card drawn!");

                        _availableCardSlots[i] = false;
                        HandIndex = i;

                        selectedCard.gameObject.SetActive(true);
                        selectedCard.transform.position = _cardSlots[i].position;
                        selectedCard.HandIndex = i;

                        _deck.Remove(selectedCard);

                        _currentHandSize++;
                        Debug.Log("Current hand size: " + _currentHandSize);
                        return;
                    }
                }
            }

            else
            {
                ShuffleInDiscardDeck();

                Card selectedCard = ChooseRandomCard();

                for (int i = 0; i < _availableCardSlots.Length; i++)
                {
                    if (_availableCardSlots[i])
                    {
                        //Debug.Log(selectedCard.CardName.text + " card drawn!");

                        _availableCardSlots[i] = false;
                        HandIndex = i;

                        selectedCard.gameObject.SetActive(true);
                        selectedCard.transform.position = _cardSlots[i].position;
                        selectedCard.HandIndex = i;

                        _deck.Remove(selectedCard);

                        _currentHandSize++;
                        Debug.Log("Current hand size: " + _currentHandSize);
                        return;
                    }
                }
            }
        }
    }

    public Card ChooseRandomCard()
    {
        Card selectedCard = _deck[UnityEngine.Random.Range(0, _deck.Count - 1)];

        return selectedCard;
    }

    public void ShuffleInDiscardDeck()
    {
        foreach (Card card in _discardDeck)
        {
            _deck.Add(card);
        }

        _discardDeck.Clear();
        Debug.Log("Deck re-shuffled!");
    }

    private int VerifyCurrentHandSize()
    {
        int currentHandSize = 3;

        for (int i = 0; i < _availableCardSlots.Length; i++)
        {
            if (_availableCardSlots[i])
            {
                currentHandSize--;
            }
        }

        return currentHandSize;
    }

    public void PlaySelectedCards()
    {
        if (_selectedCards.Count == _numCardsToPlay)
        {
            for (int i = 0; i < _numCardsToPlay; i++)
            {
                _selectedCards[i].PlayCard();
                _playedCards.Add(_selectedCards[i]);
            }

            _selectedCards.Clear();
            CardsPlayed?.Invoke();
        }

        else if (_selectedCards.Count < 2)
        {
            Debug.Log("Not enough cards selected.");
        }

        else
        {
            Debug.Log("Too many cards selected.");
        }
    }

    public void LoadCardStats()
    {
        if (_cardStats.Length > 0)
        {
            for (int i = 0; i < _cardStats.Length; i++)
            {
                int random = UnityEngine.Random.Range(i, _cardStats.Length);
                int arrayValue = _cardStats[random];
                _cardStats[random] = _cardStats[i];
                _cardStats[i] = arrayValue;

                //Debug.Log((ActionType)i + " has a value of " + _cardStats[i] + "!");
            }
        }
    }

    public int CalculateDamage()
    {
        ActionType firstCardAction = _playedCards[0].CardAction;
        int firstCardEnumIndex = (int)firstCardAction;

        ActionType secondCardAction = _playedCards[1].CardAction;
        int secondCardEnumIndex = (int)secondCardAction;

        int damage = _cardStats[firstCardEnumIndex] * _cardStats[secondCardEnumIndex];

        _playedCards.Clear();
        _currentHandSize -= 2;

        return damage;
    }
}
