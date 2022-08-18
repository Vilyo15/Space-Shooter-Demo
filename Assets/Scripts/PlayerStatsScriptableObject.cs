using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStatsScriptableObject", order = 1)]
public class PlayerStatsScriptableObject : ScriptableObject
{
    [Header("Player Prefab")]
    public GameObject player;

    [Header("Player Stats")]
    public int playerID;
    public int maxHealthPoints;
    public int healthPoints;
    public float experiencePointsCurrent;
    public float experiencePointsNeeded;
    public float playerLevel;
    public int Score;
    public Vector3 startLocation;
    public int nukeCount;

    [Header("Bullet variables")]
    public int bulletSpeed;
    public int bulletDamage;
    public int bulletQuantity;


    [Header("Shield variables")]
    public bool hasShield;
    public int shieldStrenght;
    public int shieldRecovery;


}
