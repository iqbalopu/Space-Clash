using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthComponent player1Health;
    [SerializeField] private HealthComponent player2Health;

    public UnityEvent<string> onMatchOver;

    private void Start()
    {
        player1Health.onDeath.AddListener(OnPlayer1Dead);
        player2Health.onDeath.AddListener(OnPlayer2Dead);
    }

    private void OnPlayer1Dead()
    {
        MatchOver("Player 2 Wins");
    }

    private void OnPlayer2Dead()
    {
        MatchOver("Player 1 Wins");
    }

    private void MatchOver(string result)
    {
        onMatchOver.Invoke(result);
        Time.timeScale = 0f;
    }
}
