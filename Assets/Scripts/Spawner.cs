using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private PlayerStatsScriptableObject playerStats;

    public int spawnCount;
   
    void Start()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
        Invoke("SpawnEnemyRepeat", Random.Range(1.0f, 3.0f));
        Invoke("SpawnMeteorRepeat", Random.Range(8f, 11.0f));
    }

    // Update is called once per frame
    void Update()
    {
        spawnCount = ((int)playerStats.playerLevel / 5) + 1;
    }

    public Vector2 GetPointOnUnitCircleCircumference()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        return new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).normalized;
    }

    void SpawnEnemy(float level)
    {
        
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject enemy = EnemyPool.SharedInstance.GetPooledObject((int)level % 5);
            if (enemy != null)
            {
                enemy.transform.position = GetPointOnUnitCircleCircumference() * 60;
                enemy.GetComponent<BoxCollider2D>().enabled = true;
                enemy.GetComponent<SpriteRenderer>().color = Color.white;
                enemy.SetActive(true);
            }
        }
        

    }

    private void SpawnEnemyRepeat()
    {
        float randomTime = Random.Range(1.0f, 3.0f);
        SpawnEnemy(playerStats.playerLevel);
        Invoke("SpawnEnemyRepeat", randomTime);
    }

    void SpawnMeteor()
    {
        GameObject meteor = MeteorPool.SharedInstance.GetPooledObject();
        if (meteor != null)
        {
            meteor.transform.position = new Vector3(Random.Range(-30,30), Random.Range(-30, 30),0);
            
            meteor.GetComponent<PolygonCollider2D>().enabled = true;
            meteor.SetActive(true);
        }
    }

    private void SpawnMeteorRepeat()
    {
        float randomTime = Random.Range(10.0f, 15.0f);
        SpawnMeteor();
        Invoke("SpawnMeteorRepeat", randomTime);
    }

}
