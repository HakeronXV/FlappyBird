using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Playing, GameOver }
    public GameState gameState;

    private void Start()
    {
        gameState = GameState.Playing;
    }

    private void Update()
    {
        Time.timeScale = gameState switch
        {
            GameState.Playing => 1f,
            GameState.GameOver => 0f,
            _ => Time.timeScale
        };
    }
}
