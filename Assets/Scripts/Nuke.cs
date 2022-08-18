using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Animator>().Play("NukeAnimation");
    }


    public void DestroySelf()
    {
        gameObject.SetActive(false);

    }

}
