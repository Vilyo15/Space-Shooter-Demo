using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private HighScoreScriptableObject highScoreManager;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private Text scoreText;

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        highScoreManager.Save();
        Application.Quit();
    }

    public void HighScoreButton()
    {
        mainCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        highScoreManager.Load();
        scoreText.text = null;
        for (int i = 0; i < highScoreManager.HighScoresCount; i++)
        {
            
            scoreText.text =  scoreText.text + "\n" + (i + 1).ToString() + ". " + highScoreManager[i].ToString();
        }
    }

    public void BackButton()
    {
        scoreCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}

