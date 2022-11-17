using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Card> _deck = new List<Card>();
    [SerializeField] Transform[] _cardSlots;

    private bool[] _availableCardSlots;

    public void DrawCard()
    {
        // Only draw if cards are available
        if (_deck.Count >= 1)
        {
            // Select a random card
            Card selectedCard = _deck[Random.Range(0, _deck.Count)];

            for (int i = 0; i < _availableCardSlots.Length; i++)
            {
                if (_availableCardSlots[i])
                {
                    selectedCard.gameObject.SetActive(true);
                    selectedCard.transform.position = _cardSlots[i].position;
                    _availableCardSlots[i] = false;
                    _deck.Remove(selectedCard);
                    return;
                }
            }
        }

        Debug.Log("Card drawn!");
    }


}
