using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private GameObject muzzle;
    [HideInInspector] public PlayerStatsScriptableObject playerStats;
    [SerializeField] private GameObject nuke;
    private float offset = -90f;
    private float shootTimer;
    private int speed = 20;

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

            if (Input.GetKey(KeyCode.W) && transform.position.y < 35)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.up, Space.World);
            }
            if (Input.GetKey(KeyCode.S) && transform.position.y > -35)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.down, Space.World);
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -35)
            { 
                transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World); 
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x <= 35)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.right, Space.World);
            }
            if (shootTimer >= 0)
                shootTimer -= Time.deltaTime * playerStats.bulletSpeed;

            //Shoot
            if (shootTimer <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    shootTimer = 1;   
                    Shoot();

                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Nuke();
            }
        }

        



    }


    void Shoot()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
            bullet.SetActive(true);
            transform.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerStats.healthPoints--;
        if(collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().PlayerHit();
        }
        StartCoroutine(FlashSprite());
        Debug.Log("enemyhit" + playerStats.healthPoints);  
    }

    void Nuke()
    {
        
        if (playerStats.nukeCount > 0)
        {
            Instantiate(nuke, transform.position, Quaternion.identity);
            foreach (List<GameObject> list in EnemyPool.SharedInstance.allPooledEnemies)
            {
                foreach (GameObject go in list)
                {
                    if (go.activeSelf)
                    {
                        go.GetComponent<Enemy>().DestroySelf();
                    }
                }
                    
            }
            foreach (GameObject go in MeteorPool.SharedInstance.pooledMeteors)
            {
                go.GetComponent<Meteor>().DestroySelf();
            }
            playerStats.nukeCount--;
        }    
    }

    IEnumerator FlashSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }
}
