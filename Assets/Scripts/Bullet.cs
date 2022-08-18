using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public PlayerStatsScriptableObject playerStats;
    [SerializeField] private Sprite[] bulletSprites;
    private float bulletSpeed = 20;
    private float startTime;
    private float timeToLive = 6f;
    // Start is called before the first frame update
    void OnEnable()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeToLive)
        {
            gameObject.SetActive(false);
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = bulletSprites[playerStats.bulletQuantity - 1];
        transform.Translate(bulletSpeed * Time.deltaTime * Vector2.up);
    }



    private void DestroySelf()
    {
        gameObject.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        DestroySelf();
    }
}
