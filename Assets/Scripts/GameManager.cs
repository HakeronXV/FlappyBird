using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Playing, GameOver }
    public GameState gameState;

    void Start()
    {
        gameState = GameState.Playing;
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                break;
            
            
        }
    }
}
