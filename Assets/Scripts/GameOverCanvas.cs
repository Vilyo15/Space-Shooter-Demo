using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject gamePausedText;
    [SerializeField] private HighScoreScriptableObject highScoreManager;
    private PlayerStatsScriptableObject playerStats;

    private void Start()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
    }

    public void ShowPaused()
    {
        gamePausedText.SetActive(true);
    }

    public void ShowOver()
    {
        gameOverText.SetActive(true);
    }

    private void OnDisable()
    {
        gameOverText.SetActive(false);
        gamePausedText.SetActive(false);
    }
    public void MenuButton()
    {
        highScoreManager.SubmitHighScore(playerStats.Score);
        highScoreManager.Save();
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgainButton()
    {
        highScoreManager.SubmitHighScore(playerStats.Score);
        highScoreManager.Save();
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadSceneAsync("Game");
        
    }

    public void ExitGameButton()
    {
        highScoreManager.SubmitHighScore(playerStats.Score);
        highScoreManager.Save();
        Application.Quit();
    }
}
