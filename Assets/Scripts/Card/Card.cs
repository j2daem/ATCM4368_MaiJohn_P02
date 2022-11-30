using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    [SerializeField] private ActionType _cardAction;
    [SerializeField] private TextMeshProUGUI _cardName;
    [SerializeField] private Image _cardBackground;

    [SerializeField] GameManager GameManager;
    private bool _cardSelected;
    private int _handIndex;

    public TextMeshProUGUI CardName => _cardName;
    public Image CardBackground => _cardBackground;
    public ActionType CardAction => _cardAction;
    public bool CardSelected => _cardSelected;
    public int HandIndex { get; set; }

    private void Awake()
    {
        _cardSelected = false;
    }

    public void SelectCard()
    {
        if (!_cardSelected)
        {
            transform.position += Vector3.up * 50;
            GameManager.SelectedCards.Add(this);
            _cardSelected = true;
        }

        else if (_cardSelected)
        {
            transform.position -= Vector3.up * 50;
            GameManager.SelectedCards.Remove(this);
            _cardSelected = false;
        }
    }

    public void PlayCard()
    {
        GameManager._availableCardSlots[HandIndex] = true;

        MoveToDiscardDeck();
    }

    public void MoveToDiscardDeck()
    {
        gameObject.SetActive(false);
        _cardSelected = false;
        GameManager.DiscardDeck.Add(this);
        gameObject.SetActive(false);
        //Debug.Log("Discard deck total: " + GameManager.DiscardDeck.Count);
    }
}
