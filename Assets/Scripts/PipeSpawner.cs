using System.Collections;
using UnityEngine;

public class SpawnPipeManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float repeatRate = 5f;
    private PipePool _pipePool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pipePool = GetComponent<PipePool>();
        
        InvokeRepeating(nameof(SpawnPipe), 0, repeatRate);
    }

    private void SpawnPipe()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x,Random.Range(-3,3));
        GameObject availablePipe = _pipePool.GetFirstAvailablePipe();
        availablePipe.transform.position = spawnPosition;
        availablePipe.SetActive(true);
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}