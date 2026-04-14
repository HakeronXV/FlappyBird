using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [Header("PipeMovement Settings")]
    [Range(1f, 10f)]
    public float speed = 2f;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
}