using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    private PlayerStatsScriptableObject playerStats;

    [SerializeField] private Text levelText;

    [Header("XP Bar")]
    [SerializeField] private Image xpFill;
    [SerializeField] private Text xpText;
    private float maxXP;
    private float currentXP;
    private float xpFillAmount;

    [Header("HP Bar")]
    [SerializeField] private Image hpFill;
    [SerializeField] private Text hpText;

    [Header("Score")]
    [SerializeField] private Text score;


    private float maxHP;
    private float currentHP;
    private float hpFillAmount;

    [Header("Nuke")]
    [SerializeField] private Text nukeText;

    private void Start()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
    }
    // Update is called once per frame
    void Update()
    {
        GetXPFill();
        setXPText();
        levelText.text = playerStats.playerLevel.ToString();
        nukeText.text = ("x" + playerStats.nukeCount.ToString());
        score.text = playerStats.Score.ToString();
        GetHPFill();
        setHPText();
    }

    void GetXPFill()
    {
        currentXP = playerStats.experiencePointsCurrent;
        maxXP = playerStats.experiencePointsNeeded;
        xpFillAmount =  currentXP / maxXP;
        xpFill.fillAmount = xpFillAmount;
    }

    void setXPText() 
    {
        xpText.text = (currentXP.ToString() + " / " + ((int)maxXP).ToString());
    }

    void GetHPFill()
    {
        currentHP = playerStats.healthPoints;
        maxHP = playerStats.maxHealthPoints;
        hpFillAmount = currentHP / maxHP;
        hpFill.fillAmount = hpFillAmount;
    }

    void setHPText()
    {
        hpText.text = (currentHP.ToString() + " / " + ((int)maxHP).ToString());
    }
}
