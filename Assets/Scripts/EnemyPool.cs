using System.Collections.Generic;
using UnityEngine;


public class EnemyPool : MonoBehaviour
{
    public static EnemyPool SharedInstance;
    public List<GameObject> pooledEnemies;
    public List<List<GameObject>> allPooledEnemies;
    private PlayerStatsScriptableObject playerStats;
    private GameObject objectToPool;
    public int amountToPool;
    [HideInInspector] public Transform player;
    [SerializeField] private EnemySpawnScriptableObject[] enemySpawners;

    private void Awake()
    {
        SharedInstance = this;

    }

    private void Start()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
        allPooledEnemies = new List<List<GameObject>>();
        foreach (EnemySpawnScriptableObject scripObj in enemySpawners)
        {
            pooledEnemies = new List<GameObject>();
            objectToPool = scripObj.CreateEnemy();
            GameObject tmp;
            for (int i = 0; i < scripObj.quantity; i++)
            {
                tmp = Instantiate(objectToPool, transform);
                Enemy reference = tmp.GetComponent<Enemy>();
                reference.experiencePoints = scripObj.enemy.experiencePoints;
                reference.score = scripObj.enemy.scoreWorth;
                reference.player = player;
                reference.playerStats = playerStats;
                tmp.SetActive(false);
                pooledEnemies.Add(tmp);
            }
            allPooledEnemies.Add(pooledEnemies);
        }


    }
    public GameObject GetPooledObject(int level)
    {

        for (int i = 0; i < allPooledEnemies[level].Count; i++)
        {
            if (!allPooledEnemies[level][i].activeInHierarchy)
            {
                return allPooledEnemies[level][i];
            }
        }
        return null;
    }


    public void RiseSpeed()
    {
        foreach (List<GameObject> list in allPooledEnemies)
        {
            foreach (GameObject obj in list)
            {
                obj.GetComponent<Enemy>().speed++;
            }
        }

    }

}
