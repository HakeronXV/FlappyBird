using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        playButton.onClick.AddListener(OnplayGameButtonClick);
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
    private void OnplayGameButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
