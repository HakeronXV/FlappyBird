using System.Threading;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;

    public void DisplayGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void DisplayScore(int score)
    {
        Debug.Log("Score: " + score);
    }

    public bool DisplayPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        return true;
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