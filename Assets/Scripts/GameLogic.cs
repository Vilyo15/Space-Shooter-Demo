using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private PlayerStatsScriptableObject playerStats;

    [SerializeField] private GameObject gameOverScreen;
    
    [SerializeField] private LevelUpCanvas levelUpCanvas;

    void Start()
    {
        Time.timeScale = 1;
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
        levelUpCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
        if (playerStats.healthPoints <= 0)
        {
            Time.timeScale = 0;
            gameOverScreen.gameObject.SetActive(true);
            gameOverScreen.GetComponent<GameOverCanvas>().ShowOver();
        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOverScreen.gameObject.activeSelf == false)
            {
                Time.timeScale = 0;
                gameOverScreen.gameObject.SetActive(true);
                gameOverScreen.GetComponent<GameOverCanvas>().ShowPaused();
            }
            else
            {
                Time.timeScale = 1;
                gameOverScreen.gameObject.SetActive(false);
            }
           
        }
    }

    void LevelUp()
    {
        if (playerStats.experiencePointsCurrent >= playerStats.experiencePointsNeeded)
        {
            playerStats.playerLevel++;
            playerStats.experiencePointsCurrent = 0;
            playerStats.experiencePointsNeeded = playerStats.experiencePointsNeeded * 1.5f;
            EnemyPool.SharedInstance.RiseSpeed();
            levelUpCanvas.gameObject.SetActive(true);
        }
    }
}
