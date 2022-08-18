using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpCanvas : MonoBehaviour
{
    private PlayerStatsScriptableObject playerStats;

    [SerializeField] private ButtonScriptableObject[] buttonScriptableObjects;
    [SerializeField] private Button[] buttonGameObjects;
    [SerializeField] private Text titleText;

    private int indexOne;
    private int indexTwo;
    private int indexThree;

    private void OnEnable()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
        Time.timeScale = 0;
        titleText.text = ("Reached Level " + playerStats.playerLevel.ToString() + "!");
        indexOne = Random.Range(0, buttonScriptableObjects.Length);
        indexTwo = Random.Range(0, buttonScriptableObjects.Length);
        indexThree = Random.Range(0, buttonScriptableObjects.Length);
        UpdateButtons();
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    private void UpdateButtons()
    {
        buttonGameObjects[0].image.sprite = buttonScriptableObjects[indexOne].image;
        buttonGameObjects[1].image.sprite = buttonScriptableObjects[indexTwo].image;
        buttonGameObjects[2].image.sprite = buttonScriptableObjects[indexThree].image;
        buttonGameObjects[0].GetComponentInChildren<Text>().text = buttonScriptableObjects[indexOne].description;
        buttonGameObjects[1].GetComponentInChildren<Text>().text = buttonScriptableObjects[indexTwo].description;
        buttonGameObjects[2].GetComponentInChildren<Text>().text = buttonScriptableObjects[indexThree].description;
    }
    public void ButtonOne()
    {
        
        switch (buttonScriptableObjects[indexOne].category)
        {
            case Effect.maxHealthPoints:
                playerStats.maxHealthPoints += buttonScriptableObjects[indexOne].power;
                break;
            case Effect.bulletSpeed:
                playerStats.bulletSpeed += buttonScriptableObjects[indexOne].power;
                break;
            case Effect.bulletDamage:
                playerStats.bulletDamage += buttonScriptableObjects[indexOne].power;
                break;
            case Effect.bulletQuantity:
                if (playerStats.bulletQuantity < 4)
                {
                    playerStats.bulletQuantity += buttonScriptableObjects[indexOne].power;
                }
                break;
            case Effect.hasShield:
                playerStats.hasShield = true;
                break;
            case Effect.shieldStrenght:
                playerStats.shieldStrenght += buttonScriptableObjects[indexOne].power;
                break;
            case Effect.shieldRecovery:
                playerStats.shieldRecovery += buttonScriptableObjects[indexOne].power;
                break;
            case Effect.nuke:
                playerStats.nukeCount += buttonScriptableObjects[indexOne].power;
                break;
            case Effect.heal:
                playerStats.healthPoints = playerStats.maxHealthPoints;
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }
    public void ButtonTwo()
    {
        
        switch (buttonScriptableObjects[indexTwo].category)
        {
            case Effect.maxHealthPoints:
                playerStats.maxHealthPoints += buttonScriptableObjects[indexTwo].power;
                break;
            case Effect.bulletSpeed:
                playerStats.bulletSpeed += buttonScriptableObjects[indexTwo].power;
                break;
            case Effect.bulletDamage:
                playerStats.bulletDamage += buttonScriptableObjects[indexTwo].power;
                break;
            case Effect.bulletQuantity:
                if (playerStats.bulletQuantity < 4)
                {
                    playerStats.bulletQuantity += buttonScriptableObjects[indexTwo].power;
                }
                break;
            case Effect.hasShield:
                playerStats.hasShield = true;
                break;
            case Effect.shieldStrenght:
                playerStats.shieldStrenght += buttonScriptableObjects[indexTwo].power;
                break;
            case Effect.shieldRecovery:
                playerStats.shieldRecovery += buttonScriptableObjects[indexTwo].power;
                break;
            case Effect.nuke:
                playerStats.nukeCount += buttonScriptableObjects[indexTwo].power;
                break;
            case Effect.heal:
                playerStats.healthPoints = playerStats.maxHealthPoints;
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }
    public void ButtonThree()
    {
        
        switch (buttonScriptableObjects[indexThree].category)
        {
            case Effect.maxHealthPoints:
                playerStats.maxHealthPoints += buttonScriptableObjects[indexThree].power;
                break;
            case Effect.bulletSpeed:
                playerStats.bulletSpeed += buttonScriptableObjects[indexThree].power;
                break;
            case Effect.bulletDamage:
                playerStats.bulletDamage += buttonScriptableObjects[indexThree].power;
                break;
            case Effect.bulletQuantity:
                if (playerStats.bulletQuantity < 4)
                {
                    playerStats.bulletQuantity += buttonScriptableObjects[indexThree].power;
                }
                break;
            case Effect.hasShield:
                playerStats.hasShield = true;
                break;
            case Effect.shieldStrenght:
                playerStats.shieldStrenght += buttonScriptableObjects[indexThree].power;
                break;
            case Effect.shieldRecovery:
                playerStats.shieldRecovery += buttonScriptableObjects[indexThree].power;
                break;
            case Effect.nuke:
                playerStats.nukeCount += buttonScriptableObjects[indexThree].power;
                break;
            case Effect.heal:
                playerStats.healthPoints = playerStats.maxHealthPoints;
                break;
            default:
                break;
        }
        gameObject.SetActive(false);    
    }
}
