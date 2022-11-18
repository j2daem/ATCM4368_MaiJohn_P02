using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Card> _deck = new List<Card>();
    [SerializeField] Transform[] _cardSlots;
    [SerializeField] int _cardsToPlay = 2;

    List<Card> _selectedCards = new List<Card>();
    List<Card> _playedCards = new List<Card>();
    List<Card> _discardDeck = new List<Card>();
    private Card[] _cardsInHand;
    private int _currentHandSize;
    private int _maxHandSize;

    #region Getters/Setters
    public List<Card> SelectedCards => _selectedCards;
    public List<Card> PlayedCards => _playedCards;
    public List<Card> DiscardDeck => _discardDeck;
    public int CurrentHandSize => _currentHandSize;
    public int MaxHandSize => _maxHandSize;
    #endregion

    public event Action CardsPlayed = delegate { };

    private void Awake()
    {
        _cardsInHand = new Card[_cardSlots.Length];

        for (int i = 0; i < _cardsInHand.Length; i++)
        {
            _cardsInHand[i] = null;
        }

        _currentHandSize = 0;
        _maxHandSize = _cardSlots.Length;
    }

    public void DrawCard()
    {
        if (_currentHandSize < _maxHandSize)
        {
            Card selectedCard = _deck[UnityEngine.Random.Range(0, _deck.Count)];

            if (_deck.Count >= 1)
            {
                for (int i = 0; i < _cardsInHand.Length; i++)
                {
                    if (_cardsInHand[i] == null)
                    {
                        Debug.Log(selectedCard.CardName.text + " card drawn!");

                        _cardsInHand[i] = selectedCard;

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

    public void PlaySelectedCards()
    {
        if (_selectedCards.Count == _cardsToPlay)
        {
            for (int i = 0; i < _cardsToPlay; i++)
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
}
