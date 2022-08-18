using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> pooledBullets;
    public GameObject objectToPool;
    public int amountToPool;
    private PlayerStatsScriptableObject playerStats;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
        pooledBullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, transform);
            tmp.GetComponent<Bullet>().playerStats = playerStats;
            tmp.SetActive(false);
            pooledBullets.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }
}
