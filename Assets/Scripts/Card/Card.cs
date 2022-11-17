using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ActionType
{
    chat,
    flirt,
    insult,
    joke
}

public class Card : MonoBehaviour
{
    [SerializeField] private ActionType _cardAction;
    [SerializeField] private TextMeshProUGUI _cardName;
    [SerializeField] private Image _cardBackground;

    private bool _cardPlayed;
    private int _handIndex;

    public TextMeshProUGUI CardName => _cardName;
    public Image CardBackground => _cardBackground;
    public ActionType CardAction => _cardAction;
    public int HandIndex { get; set; }
}
