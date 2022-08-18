using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPool : MonoBehaviour
{
    public static MeteorPool SharedInstance;
    public List<GameObject> pooledMeteors;
    private PlayerStatsScriptableObject playerStats;
    public int amountToPool;
    [HideInInspector] public Transform player;
    [SerializeField] private MeteorScriptableObject[] meteorSpawners;
    private GameObject tempGO;
    void Awake()
    {
        SharedInstance = this;
        
    }

    void Start()
    {
        playerStats = PlayerInit.SharedInstance.GetStatsReference();
        pooledMeteors = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(meteorSpawners[Random.Range(0,meteorSpawners.Length)].CreateEnemy(), transform);
            Meteor temp = tmp.GetComponent<Meteor>();
            temp.playerStats = playerStats;
            tmp.SetActive(false);
            pooledMeteors.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {

            if (!pooledMeteors[i].activeInHierarchy)
            {
                Shuffle(pooledMeteors);
                return pooledMeteors[i];
            }
        }
        return null;
    }

    public void Shuffle(List<GameObject> decklist)
    {
        for (int i = 0; i < decklist.Count; i++)
        {
            int rnd = Random.Range(0, decklist.Count);
            tempGO = decklist[rnd];
            decklist[rnd] = decklist[i];
            decklist[i] = tempGO;
        }
    }
}
