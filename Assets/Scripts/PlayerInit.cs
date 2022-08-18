using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public static PlayerInit SharedInstance;

    [Header("Default stats")]
    [SerializeField] private PlayerStatsScriptableObject defaultStats;

    private PlayerStatsScriptableObject currentStats;


    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStats = Instantiate(defaultStats);
        GameObject tmp = Instantiate(currentStats.player, currentStats.startLocation, Quaternion.identity);

        //set references to current game stats
        tmp.GetComponent<PlayerLogic>().playerStats = currentStats;
        EnemyPool.SharedInstance.player = tmp.transform;

        
    }


    public PlayerStatsScriptableObject GetStatsReference()
    {
        return currentStats;
    }
    
}
