using System;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Player References"), Space(10)] 
    [SerializeField, Tooltip("The player object you must instantiate at start.")] private GameObject playerPrefab;
    [SerializeField,Tooltip("The position of the player at start.")] private Transform playerSpawnPosition;
    private GameObject _bird;
    
    [Header("Managers References"), Space(10)]
    [SerializeField] private UiManager uiManager;
    
    [Header("Gameplay Data")]
    [SerializeField ]private int score;
    
    private enum STATE
    {
        Playing,
        Paused,
        GameOver
    }
    
    private STATE state = STATE.Playing;

    private void Pause()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            state = STATE.Paused;
            uiManager.DisplayPauseMenu();
        }
        while (state == STATE.Paused)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                uiManager.DisplayPauseMenu();
                enabled = false;
            }
        }
    }
        
    void Start()
    {
        _bird = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
        _bird.GetComponent<BirdController>().mManager =this;
    }

    void Update()
    {
        Pause();
    }
    public void GameOver()
    {
        uiManager.DisplayGameOverMenu();
    }

    public void AddPoint()
    {
        score++;
        uiManager.DisplayScore(score);
    }
}