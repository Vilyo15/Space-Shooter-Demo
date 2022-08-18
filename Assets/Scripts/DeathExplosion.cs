using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplosion : MonoBehaviour
{
    void Start()
    {

        gameObject.GetComponent<Animator>().Play("ExplosionAnimation");
        gameObject.GetComponent<AudioSource>().Play();
    }


    public void DestroySelf()
    {
        gameObject.SetActive(false);

    }
}
