using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject deathAnimation;
    [HideInInspector] public int healthPoints;
    [HideInInspector] public int speed;
    [HideInInspector] public int experiencePoints;
    [HideInInspector] public int score;
    [HideInInspector] public PlayerStatsScriptableObject playerStats;
    [HideInInspector] public Transform player;
    private int currentHP;

    private void Start()
    {
        currentHP = healthPoints;
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.Translate(speed * Time.deltaTime * Vector2.up);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.up = player.position - transform.position;
        if (currentHP <= 0)
        {
            DestroySelf();
        }
    }


    public void DestroySelf()
    {
        playerStats.experiencePointsCurrent += experiencePoints;
        playerStats.Score += score * ((int)playerStats.playerLevel + 1);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        currentHP = healthPoints;
        Instantiate(deathAnimation, transform.position, Quaternion.identity);

        gameObject.SetActive(false);

    }

    public void PlayerHit()
    {

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        currentHP = healthPoints;
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FlashSprite());
        currentHP -= playerStats.bulletDamage * playerStats.bulletQuantity;
    }

    private IEnumerator FlashSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }


}
