using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;
    private Rigidbody2D _rigidbody2D;
    public enum GameState { Playing, GameOver }
    public GameState gameState;
    public TMP_Text gameOverText;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected ");
    }
    private void HandleInput()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }
        }
     private void Jump()
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, Mathf.Clamp(_rigidbody2D.linearVelocity.y, -10, 10f));
            _rigidbody2D.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameState = GameState.GameOver;
                gameOverText.enabled = true;
                Debug.Log("Game Over");
            }
        }

    private void Start()
    {
        gameState = GameState.Playing;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null) Debug.LogError("No Rigidbody2D found");
        Debug.Log("Bird ready");
        
    }
    
    private void Update()
    { 
        HandleInput();
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
