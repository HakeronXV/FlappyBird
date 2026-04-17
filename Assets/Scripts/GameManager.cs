using System;
using TMPro;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player References"), Space(10)] 
    [SerializeField, Tooltip("The player object you must instantiate at start.")] private GameObject playerPrefab;
    [SerializeField,Tooltip("The position of the player at start.")] private Transform playerSpawnPosition;
    private GameObject _bird;
    [SerializeField] private TMP_Text nameInput;
    [SerializeField] private Button playButton;
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

    private STATE state;
    [SerializeField] private GameObject mainMenu;

    private void Pause()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            state = STATE.Paused;
            uiManager.DisplayPauseMenu();
        }
    }
        
    void Start()
    {
        playButton.onClick.AddListener(OnplayGameButtonClick);
        
       _bird = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
       _bird.GetComponent<BirdController>().mManager =this;

    }

    private void OnplayGameButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        mainMenu.SetActive(false);
    }

    void Update()
    {
        Pause();
    }

    internal void GameOver()
    {
        state = STATE.GameOver;
        uiManager.DisplayGameOverMenu();
    }

    internal void AddPoint()
    {
        score++;
        uiManager.DisplayScore(score);
    }
}