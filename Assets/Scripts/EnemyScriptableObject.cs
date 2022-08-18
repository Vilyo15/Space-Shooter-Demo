using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Enemy Specs")]
    public int level;
    public int healthPoints;
    public Sprite image;
    public int speed;
    public int experiencePoints;
    public int scoreWorth;

    [Header("Attach Enemy Prefab")]
    public GameObject enemyPrefab;
        
}
