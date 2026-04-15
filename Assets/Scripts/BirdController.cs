using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameManager.GameState _gameManager;
    public TMP_Text gameOverText;
    private Camera _camera;

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
        

    private void Start()
    {
        _camera = Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null) Debug.LogError("No Rigidbody2D found");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;
        _gameManager = GameManager.GameState.GameOver;
        gameOverText.enabled = true;
        Debug.Log("Game Over");
    }
    
    private void Update()
    { 
        HandleInput();
        if(Mathf.Abs(transform.position.y)>_camera.orthographicSize)
        {
            _gameManager = GameManager.GameState.GameOver;
        }
    }
}
