using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log("Bird ready"); 
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, Mathf.Clamp(_rb.linearVelocity.y, -10, 10f));
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Update()
    { 
        HandleInput();
    }
}
