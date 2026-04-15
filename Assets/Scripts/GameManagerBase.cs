/*
using UnityEngine;

public class GameManagerBase : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField, Tooltip("The player object you must instantiate at start.")] private GameObject _playerPrefab;
    [SerializeField, Tooltip("The position of the player at start.")] private GameObject _playerSpawnPosition;
    public enum GameState { Playing, GameOver }
    public GameState gameState;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject bird = Instantiate(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        bird.GetComponent<BirdController>().gameState = this;
        gameState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameState switch
        {
            GameState.Playing => 1f,
            GameState.GameOver => 0f,
            _ => Time.timeScale
        };
    }
}
*/
