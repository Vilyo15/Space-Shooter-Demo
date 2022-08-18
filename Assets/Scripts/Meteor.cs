using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [HideInInspector] public int healthPoints;
    [HideInInspector] public PlayerStatsScriptableObject playerStats;
    [SerializeField] private GameObject deathAnimation;
    private int currentHP;
    void Start()
    {
        currentHP = healthPoints;
        gameObject.GetComponent<Animator>().Play("MeteorAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            DestroySelf();
        }
    }



    public void DestroySelf()
    {
        
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        currentHP = healthPoints;
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHP -= playerStats.bulletDamage * playerStats.bulletQuantity;
    }
}
