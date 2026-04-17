using System.Threading;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;

    public void DisplayGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void DisplayScore(int score)
    {
        Debug.Log("Score: " + score);
    }

    internal void DisplayMainMenu()
    {
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }
    internal void DisplayPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void NotDisplayPauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void DisplayQuitGame()
    {
        
    }
}