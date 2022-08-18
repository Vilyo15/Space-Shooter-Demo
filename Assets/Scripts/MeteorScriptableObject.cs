using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meteor", menuName = "ScriptableObjects/MeteorScriptableObject", order = 1)]
public class MeteorScriptableObject : ScriptableObject
{
    public Sprite image;
    public int health;
    public GameObject prefab;

    public GameObject CreateEnemy()
    {
        GameObject temp = prefab;
        temp.GetComponent<SpriteRenderer>().sprite = image;
        temp.GetComponent<Meteor>().healthPoints = health;
        return temp;
    }
}
