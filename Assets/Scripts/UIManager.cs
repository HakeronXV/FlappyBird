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

    public void DisplayPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
}