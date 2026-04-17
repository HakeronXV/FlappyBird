using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text finalScoreText;

    void Start()
    {
        UpdateScore();
    }

    public void AddPoint()
    {
    score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        finalScoreText.text = "Final Score : " + score;
        highscoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
        
    }   
}
