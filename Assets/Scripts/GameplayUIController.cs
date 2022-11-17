using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] GameObject _enemyThinkingUI = null;
    [SerializeField] Card[] _deck;
    [SerializeField] CardData _chatCardData;
    [SerializeField] CardData _flirtCardData;
    [SerializeField] CardData _insultCardData;
    [SerializeField] CardData _jokeCardData;

    private void Awake()
    {
        _enemyThinkingUI.SetActive(false);
        LoadAllCardData();
    }

    private void OnEnable()
    {
        EnemyTurnState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void OnEnemyTurnBegan()
    {
        _enemyThinkingUI.SetActive(true);
    }

    private void OnEnemyTurnEnded()
    {
        _enemyThinkingUI.SetActive(false);
    }

    private void LoadAllCardData()
    {
        for (int i = 0; i < _deck.Length; i++)
        {
            switch (_deck[i].CardAction)
            {
                case ActionType.chat:
                    _deck[i].CardName.text = _chatCardData.CardName;
                    _deck[i].CardBackground.color = _chatCardData.CardColor;
                    break;

                case ActionType.flirt:
                    _deck[i].CardName.text = _flirtCardData.CardName;
                    _deck[i].CardBackground.color = _flirtCardData.CardColor;
                    break;

                case ActionType.insult:
                    _deck[i].CardName.text = _insultCardData.CardName;
                    _deck[i].CardBackground.color = _insultCardData.CardColor;
                    break;

                case ActionType.joke:
                    _deck[i].CardName.text = _jokeCardData.CardName;
                    _deck[i].CardBackground.color = _jokeCardData.CardColor;
                    break;

                default:
                    Debug.Log("Action type not assigned to card.");
                    break;
            }
        }
    }
}
