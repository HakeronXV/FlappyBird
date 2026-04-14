using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, spawnRate);
    }

    private void SpawnPipe()
    {
        var randomY = Random.Range(-2f, 2f);
        var spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);

    }
}