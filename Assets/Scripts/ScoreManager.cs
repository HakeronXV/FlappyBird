using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text nameInput;
    [SerializeField]private Transform scoreList;
    [SerializeField]private Transform mainMenu;

    private void Start()
    {
        const float templateHeigh = 30f;
        for (var i = 0; i < 10; i++)
        {
            var entryTransform = Instantiate(scoreList, mainMenu);
            var entryRectTransform = scoreList.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(60, -templateHeigh * i);
            entryTransform.gameObject.SetActive(true);
            var rank = i + 1;
            var rankString = rank switch
            {
                1 => "1ST",
                2 => "2ND",
                3 => "3RD",
                _ => rank + "TH"
            };
            entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = rankString;
            entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = nameInput.text;
        }
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
