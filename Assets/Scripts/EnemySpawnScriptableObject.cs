using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawn", menuName = "ScriptableObjects/EnemySpawnScriptableObject", order = 1)]
public class EnemySpawnScriptableObject : ScriptableObject
{
    
    public EnemyScriptableObject enemy;
    public int quantity;
   

    public GameObject CreateEnemy()
    {
        GameObject temp = enemy.enemyPrefab;
        temp.name = enemy.name;
        temp.GetComponent<SpriteRenderer>().sprite = enemy.image;
        temp.GetComponent<Enemy>().healthPoints = enemy.healthPoints;
        temp.GetComponent<Enemy>().speed = enemy.speed;
        temp.GetComponent<Enemy>().experiencePoints = enemy.experiencePoints;
        return temp;
    }
}
