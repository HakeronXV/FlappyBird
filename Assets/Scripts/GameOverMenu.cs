using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        retryButton.onClick.AddListener(OnRetryGameButtonClick);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else Application.Quit ();
    }

    private void OnRetryGameButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
