using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Data", fileName = "_CARD")]
public class CardData : ScriptableObject
{
    [SerializeField] string _cardName;
    [SerializeField] Color _cardColor;

    public string CardName => _cardName;
    public Color CardColor => _cardColor;
}
